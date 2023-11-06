using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    [TableName("AuthorizationToken")]

    public class AuthorizationToken
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
