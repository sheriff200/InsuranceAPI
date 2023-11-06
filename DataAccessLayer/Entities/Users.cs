using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    [TableName("Users")]
    public class Users
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
