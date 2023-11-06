using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model.Dto.Request
{
    public class AllPolicyHolderClaimRequest
    {
        
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Only number is allowed")]
        public long PageNumber { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Only number is allowed")]
        public long PageSize { get; set; }
    }
}
