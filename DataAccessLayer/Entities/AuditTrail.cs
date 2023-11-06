using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    [TableName("AuditTrail")]
    public class AuditTrail
    {
        public long Id { get; set; }
        public string Browser { get; set; }
        public string IPAddress { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public DateTime ActivityTime { get; set; } = DateTime.Now;
    }
}
