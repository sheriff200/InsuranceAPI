using DataAccessLayer;
using DataAccessLayer.Cryptography;
using DataAccessLayer.Entities;
using DataAccessLayer.Model.Dto.Request;
using DataAccessLayer.Model.Dto.Response;
using DataAccessLayer.Serilog;
using InfrastructureLayer.IServices;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class AccountService : IAccountService
    {
        private readonly ISerilogger _seriLogger;
        private readonly AppSettings  _appSettings;
        private readonly IDBService _dbservices;
        private readonly IAuditService _auditService;
        private readonly string directory = "AccountService";
        public AccountService(ISerilogger seriLogger, IOptions<AppSettings> appSettings, IDBService dbservices, IAuditService auditService)
        {
            _seriLogger = seriLogger;
            _appSettings = appSettings.Value;
            _dbservices = dbservices;
            _auditService = auditService;
        }

        public async Task<WebApiResponse> ValidateUserLogin(ValidateUserRequest model)
        {
            try
            {
                var result = _dbservices.GetAll<Users>().Where(x=>x.UserName == model.Username && x.Password == SHA256Crypto.Encrypt(model.Password)).FirstOrDefault();

                if(result != null)
                {
                    if(result.Role.ToLower() != model.Role.ToLower())
                    {
                        _seriLogger.LogRequest("Invalid user role " + model.Role, true, directory);
                        return new WebApiResponse { ResponseCode = ApiResponseCode.BadRequest, StatusCode = ApiResponseCode.BadRequest, Message = "Invalid user role"};
                    }

                    var tokenHandler = new JwtSecurityTokenHandler();
                    LoginResponse loginResponse = new LoginResponse();

                    var tokenKey = Encoding.UTF8.GetBytes(SHA256Crypto.Decrypt(_appSettings.JWTKey));
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                      {
                      new Claim(ClaimTypes.Role, model.Role),
                      new Claim(ClaimTypes.Name, model.Username),
                      }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    loginResponse.UserRole = model.Role;
                    loginResponse.Username = model.Username;
                    loginResponse.Token = tokenHandler.WriteToken(token);
                    loginResponse.RefreshToken = GenerateRefreshToken();
                    loginResponse.RefreshTokenExpiryTime = DateTime.Now.AddHours(1);
                    var savedata = new AuthorizationToken() { Username = loginResponse.Username, AccessToken = SHA256Crypto.Encrypt(loginResponse.Token), RefreshToken = SHA256Crypto.Encrypt(loginResponse.RefreshToken), RefreshTokenExpiryTime = loginResponse.RefreshTokenExpiryTime };
                    await _dbservices.Add(savedata);

                    _seriLogger.LogRequest($"{"ValidateUserLogin -- Record was successfully retrieved."} {"|"} {"Data =" + JsonConvert.SerializeObject(loginResponse)}", false, directory);
                    _auditService.AuditTrail(model.Username, "LogIn");
                    return new WebApiResponse { ResponseCode = ApiResponseCode.Success, StatusCode = ApiResponseCode.StatusOk, Message = "Record was successfully retrieved", Data = loginResponse };


                }
                else
                {
                    _seriLogger.LogRequest("Invalid username or password", true, directory);

                    return new WebApiResponse { ResponseCode = ApiResponseCode.BadRequest, StatusCode = ApiResponseCode.BadRequest, Message = "Invalid username or password" };
                }
            }
            catch(Exception ex)
            {
                _seriLogger.LogRequest(ex.ToString(), true, directory);
                return new WebApiResponse { ResponseCode = ApiResponseCode.InternalServerError, StatusCode = ApiResponseCode.InternalServerError, Message = ex.ToString() };

            }
        }

        public async Task<WebApiResponse> AuthenticationRefresher(TokenRequest model)
        {
            try
            {
                var principal = GetPrincipalFromExpiredToken(model?.AccessToken);
                var username = principal.Identity.Name; 
                var user = await _dbservices.GetAuthorizedUserByUserName<AuthorizationToken>(username);
                var userrecord = (AuthorizationToken)user?.Data;
                if (userrecord is null || SHA256Crypto.Decrypt(userrecord?.RefreshToken) != model?.RefreshToken || userrecord.RefreshTokenExpiryTime <= DateTime.Now)
                    return new WebApiResponse { ResponseCode = ApiResponseCode.BadRequest, Message = "Invalid client request", StatusCode = ApiResponseCode.BadRequest };

                var newAccessToken = GenerateAccessToken(principal.Claims);
                var newRefreshToken = GenerateRefreshToken();

                var returndata = new TokenRequest() { AccessToken = newAccessToken, RefreshToken = newRefreshToken };
                userrecord.RefreshToken = newRefreshToken;
                userrecord.AccessToken = newAccessToken;
                await _dbservices.Update(userrecord);
                _auditService.AuditTrail(username, "Generate refresh token");
                return new WebApiResponse { ResponseCode = ApiResponseCode.Success, Message = "Successful", StatusCode = ApiResponseCode.Success, Data = returndata };
            }
            catch (Exception ex)
            {
                _seriLogger.LogRequest(ex.ToString(), true, directory);
                return new WebApiResponse { ResponseCode = ApiResponseCode.InternalServerError, StatusCode = ApiResponseCode.InternalServerError, Message = ex.ToString() };

            }
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }


        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SHA256Crypto.Decrypt(_appSettings.JWTKey))),
                ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }


        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SHA256Crypto.Decrypt(_appSettings.JWTKey)));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }
    }
}
