using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    [TableName("Claims")]
    public class Claims
    {
        public long Id {get;set;}
        public long ClaimID { get;set;}
        public long NationalIDNumber { get;set;}
        public string Expenses { get;set;}
        public decimal ExpenseAmount { get;set;}
        public DateTime ExpenseDate { get;set;}
        public string ClaimStatus { get;set;}
        public string LastProcessor { get;set;}
        public int AppStage { get;set;}
        public int NextStage { get;set;}
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
