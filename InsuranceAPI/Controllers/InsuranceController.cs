using Azure;
using DataAccessLayer.Model.Dto.Request;
using DataAccessLayer.Model.Dto.Response;
using InfrastructureLayer.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InsuranceAPI.Controllers
{
    //[Authorize]
    [Route("api/insurance")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceService _insuranceService;
        public InsuranceController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        [Authorize(Roles = "PolicyHolder")]
        [HttpPost]
        [Route("policy-holders-claim")]
        public async Task<IActionResult> PolicyHolderClaims([FromForm] PolicyHolderClaimRequest model)
        {
          var response =  await _insuranceService.PolicyHolderClaims(model);

            if (response?.StatusCode == ApiResponseCode.Failed)
                return StatusCode((int)HttpStatusCode.ExpectationFailed, response);

            else if (response?.StatusCode == ApiResponseCode.InternalServerError)
                return StatusCode((int)HttpStatusCode.InternalServerError, response);

            else 
                return StatusCode((int)HttpStatusCode.OK, response);
        }

        [Authorize(Roles = "Reviewer,Approval")]
        [HttpPost]
        [Route("process-claims")]
        public async Task<IActionResult> ProcessClaims([FromBody] ProcessClaimRequest model)
        {
            var response = await _insuranceService.ProcessClaims(model);

            if (response?.StatusCode == ApiResponseCode.Failed)
                return StatusCode((int)HttpStatusCode.ExpectationFailed, response);

            else if (response?.StatusCode == ApiResponseCode.RecordNotFound)
                return StatusCode((int)HttpStatusCode.NotFound, response);

            else if (response?.StatusCode == ApiResponseCode.InternalServerError)
                return StatusCode((int)HttpStatusCode.InternalServerError, response);

            else
                return StatusCode((int)HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("all-policy-holders-claim")]
        public async Task<IActionResult> AllPolicyHolderClaims([FromForm] AllPolicyHolderClaimRequest model)
        {
            var response = await _insuranceService.AllPolicyHolderClaims(model);
           
             if (response?.StatusCode == ApiResponseCode.RecordNotFound)
                return StatusCode((int)HttpStatusCode.NotFound, response);

            else if (response?.StatusCode == ApiResponseCode.InternalServerError)
                return StatusCode((int)HttpStatusCode.InternalServerError, response);

            else
                return StatusCode((int)HttpStatusCode.OK, response);
        }

       
    }
}
