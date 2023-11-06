using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    [TableName("PolicyHolders")]
    public class PolicyHolders
    {
        public long Id { get; set; }
        public long NationalIDNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateofBirth { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
