using DataAccessLayer.Model.Dto.Request;
using DataAccessLayer.Model.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.IServices
{
    public interface IInsuranceService
    {
        Task<WebApiResponse> PolicyHolderClaims(PolicyHolderClaimRequest model);
        Task<WebApiResponse> AllPolicyHolderClaims(AllPolicyHolderClaimRequest model);
        Task<WebApiResponse> ProcessClaims(ProcessClaimRequest model);
    }
}
