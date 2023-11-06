using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model.Dto.Request
{
    public class ProcessClaimRequest
    {
        [Range(0, int.MaxValue, ErrorMessage = "Only number is allowed")]
        public long Id { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Only number is allowed")]
        public int ProcessTypeId { get; set; }
    }
}
