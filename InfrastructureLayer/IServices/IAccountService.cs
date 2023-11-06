using DataAccessLayer.Model.Dto.Request;
using DataAccessLayer.Model.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.IServices
{
    public interface IAccountService
    {
        Task<WebApiResponse> ValidateUserLogin(ValidateUserRequest model);
        Task<WebApiResponse> AuthenticationRefresher(TokenRequest model);
    }
}
