using Azure;
using DataAccessLayer.Model.Dto.Request;
using DataAccessLayer.Model.Dto.Response;
using InfrastructureLayer.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InsuranceAPI.Controllers
{
    [Route("api/insurance/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> Login([FromBody] ValidateUserRequest model)
        {
            var response = await _accountService.ValidateUserLogin(model);
                
            if (response?.StatusCode == ApiResponseCode.BadRequest)
                return StatusCode((int)HttpStatusCode.BadRequest, response);

            else if (response?.StatusCode == ApiResponseCode.InternalServerError)
                return StatusCode((int)HttpStatusCode.InternalServerError, response);

            else
                return StatusCode((int)HttpStatusCode.OK, response);
        }


        [HttpPost]
        [Route("refresh-token")]

        public async Task<IActionResult> RefreshToken([FromBody] TokenRequest model)
        {
            var response = await _accountService.AuthenticationRefresher(model);

            if (response?.StatusCode == ApiResponseCode.BadRequest)
                return StatusCode((int)HttpStatusCode.BadRequest, response);

            else if (response?.StatusCode == ApiResponseCode.InternalServerError)
                return StatusCode((int)HttpStatusCode.InternalServerError, response);

            else
                return StatusCode((int)HttpStatusCode.OK, response);
        }
    }
}
