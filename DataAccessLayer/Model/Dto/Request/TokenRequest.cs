using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model.Dto.Request
{
    public class TokenRequest
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
