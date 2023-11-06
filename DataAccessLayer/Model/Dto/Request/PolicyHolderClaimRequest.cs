using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model.Dto.Request
{
    public class PolicyHolderClaimRequest
    {
        [Required]
        public long NationalIDNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateofBirth { get; set; }

        [Required]
        public string PolicyNumber { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Only number is allowed")]
        public long ClaimID { get; set; }
        public string Expenses { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Only number is allowed")]
        public decimal ExpenseAmount { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime ExpenseDate { get; set; }
    }
}
