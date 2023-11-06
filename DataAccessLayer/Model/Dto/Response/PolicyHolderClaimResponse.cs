using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model.Dto.Response
{
    public class PolicyHolderClaimResponse
    {
        public long Id { get; set; }
        public long NationalIDNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ClaimStatus { get; set; }
        public DateTime DateofBirth { get; set; }
        public string PolicyNumber { get; set; }
        public long ClaimID { get; set; }
        public string Expenses { get; set; }
        public decimal ExpenseAmount { get; set; }
        public DateTime ExpenseDate { get; set; }
    }
}
