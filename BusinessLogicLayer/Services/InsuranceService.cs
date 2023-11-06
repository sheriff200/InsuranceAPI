using AutoMapper;
using DataAccessLayer.Emuns;
using DataAccessLayer.Entities;
using DataAccessLayer.Model.Dto.Request;
using DataAccessLayer.Model.Dto.Response;
using DataAccessLayer.Serilog;
using InfrastructureLayer.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class InsuranceService : IInsuranceService
    {
        private readonly IDBService _dbservices;
        private readonly SeriLogger _seriLogger;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuditService _auditService;
        private readonly string directory = "InsuranceServices";
        public InsuranceService(IDBService dbservices, SeriLogger seriLogger, IMapper mapper, 
            IHttpContextAccessor httpContextAccessor, IAuditService auditService)
        {

            _dbservices = dbservices;
            _seriLogger = seriLogger;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _auditService = auditService;

        }

        public async Task<WebApiResponse> PolicyHolderClaims(PolicyHolderClaimRequest model)
        {
            try
            {
                var pdata = _mapper.Map<PolicyHolders>(model);
                var presult = await _dbservices.Add(pdata);
                var username = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
                if (presult == 1)
                {
                    var cdata = _mapper.Map<Claims>(model);
                    cdata.LastProcessor = username;
                    cdata.ClaimStatus = ClaimStatus.Submit;
                    cdata.AppStage = (int)AppStages.Submitted;
                    cdata.NextStage = (int)AppStages.Reviewed;
                    var cresult = await _dbservices.Add(cdata);
                    if (cresult == 1)
                    {
                        _seriLogger.LogRequest("record saved successfully", true, directory);
                        return new WebApiResponse { ResponseCode = ApiResponseCode.Success, StatusCode = ApiResponseCode.StatusOk, Message = "successful", Data = model };
                    }
                }
                _seriLogger.LogRequest("unable to save record", true, directory);
                return new WebApiResponse { ResponseCode = ApiResponseCode.Failed, StatusCode = ApiResponseCode.Failed, Message = "Unable to save record" };

            }
            catch (Exception ex)
            {
                _seriLogger.LogRequest(ex.ToString(), true, directory);
                return new WebApiResponse { ResponseCode = ApiResponseCode.InternalServerError, StatusCode = ApiResponseCode.InternalServerError, Message = ex.ToString() };

            }

        }

        public async Task<WebApiResponse> AllPolicyHolderClaims(AllPolicyHolderClaimRequest model)
        {
            try
            {
                var username = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
                var response = await _dbservices.GetRecords<PolicyHolderClaimResponse>(model.PageNumber, model.PageSize);
                _auditService.AuditTrail(username, "Get all claims");

                if (response == null)
                {
                    _seriLogger.LogRequest("No record found", true, directory);
                    return new WebApiResponse { ResponseCode = ApiResponseCode.RecordNotFound, StatusCode = ApiResponseCode.RecordNotFound, Message = "No record found"};
                }
                else
                {
                    _seriLogger.LogRequest("Record found", false, directory);
                    return new WebApiResponse { ResponseCode = ApiResponseCode.Success, StatusCode = ApiResponseCode.StatusOk, Message = "Successful", Data = response };
                }
            }
            catch (Exception ex)
            {
                _seriLogger.LogRequest(ex.ToString(), true, directory);
                return new WebApiResponse { ResponseCode = ApiResponseCode.InternalServerError, StatusCode = ApiResponseCode.InternalServerError, Message = ex.ToString() };

            }
        }


        public async Task<WebApiResponse> ProcessClaims(ProcessClaimRequest model)
        {
            try
            {
                var username = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
                var claimrecords = _dbservices.GetAll<Claims>().Where(x => x.Id == model.Id).FirstOrDefault();
                int reviewer = (int)AppStages.Reviewed;
                int approval = (int)AppStages.Approved;
                int decline = (int)AppStages.Declined;
                int processed = (int)AppStages.Processed;

                if (claimrecords == null)
                {
                    return new WebApiResponse { ResponseCode = ApiResponseCode.RecordNotFound, StatusCode = ApiResponseCode.RecordNotFound, Message = "No record found" };
                }
                _auditService.AuditTrail(username, "Process claims");

                claimrecords.LastProcessor = username;

                if (model.ProcessTypeId == reviewer && claimrecords.NextStage == reviewer)
                {
                    claimrecords.AppStage = reviewer;
                    claimrecords.ClaimStatus = ClaimStatus.InReview;
                    claimrecords.NextStage = approval;
                }
                else if (model.ProcessTypeId == approval && claimrecords.NextStage == approval)
                {
                    claimrecords.AppStage = approval;
                    claimrecords.ClaimStatus = ClaimStatus.Approve;
                    claimrecords.NextStage = processed;
                }
                else if (model.ProcessTypeId == decline)
                {
                    claimrecords.AppStage = decline;
                    claimrecords.ClaimStatus = ClaimStatus.Decline;
                    claimrecords.NextStage = reviewer;
                }
                else
                {
                    _seriLogger.LogRequest("Invalid process type ID", true, directory);
                    return new WebApiResponse { ResponseCode = ApiResponseCode.Failed, StatusCode = ApiResponseCode.Failed, Message = "Invalid process type ID" };
                }
                var response = await _dbservices.Update(claimrecords);

                if (response == 1)
                {
                    _seriLogger.LogRequest("Successful", false, directory);
                    return new WebApiResponse { ResponseCode = ApiResponseCode.Success, StatusCode = ApiResponseCode.StatusOk, Message = "Successful" };
                }
                else
                {
                    _seriLogger.LogRequest("Unable to process claims", true, directory);
                    return new WebApiResponse { ResponseCode = ApiResponseCode.Failed, StatusCode = ApiResponseCode.Failed, Message = "Unable to process claims" };

                }
                
            }
            catch (Exception ex)
            {
                _seriLogger.LogRequest(ex.ToString(), true, directory);
                return new WebApiResponse { ResponseCode = ApiResponseCode.InternalServerError, StatusCode = ApiResponseCode.InternalServerError, Message = ex.ToString() };

            }
        }
    }
}
