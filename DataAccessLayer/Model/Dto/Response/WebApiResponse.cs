using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model.Dto.Response
{
    public class WebApiResponse
    {
        public string StatusCode { get; set; }
        public string ResponseCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

    }

    public class ApiResponseCode
    {
        public const string RecordNotFound = "404";
        public const string Failed = "02";
        public const string InternalServerError = "500";
        public const string Success = "00";
        public const string DuplicateRecord = "26";
        public const string StatusOk = "200";
        public const string Created = "201";
        public const string InsufficientFund = "51";
        public const string DuplicateTransaction = "94";
        public const string SystemTimeOut = "97";
        public const string EmptyClientReferenceNumber = "71";
        public const string InvalidTransaction = "12";
        public const string InvalidCountryId = "11";
        public const string BadRequest = "400";
    }

    public class ClaimStatus
    {
        public const string Submit = "Submitted";
        public const string Approve = "Approved";
        public const string Decline = "Declined";
        public const string InReview = "In-Review";
       
    }
}
