using DataAccessLayer.Entities;
using InfrastructureLayer.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UAParser;

namespace BusinessLogicLayer.Services
{
    public class AuditService : IAuditService
    {
        private readonly IDBService _dBService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuditService(IDBService dBService, IHttpContextAccessor httpContextAccessor)
        {
            _dBService = dBService;
            _httpContextAccessor = httpContextAccessor;
        }
        public void AuditTrail(string username, string description)
        {
            var model = new AuditTrail()
            {
                UserName = username,
                IPAddress = IPAddress(),
                Description = description,
                Browser = BrowserName(_httpContextAccessor.HttpContext)
            };
            _dBService.Add(model);
        }

        public string BrowserName(HttpContext httpContext)
        {
            var userAgent = httpContext.Request.Headers["User-Agent"].ToString();
            var uaParser = Parser.GetDefault();
            ClientInfo c = uaParser.Parse(userAgent);
            return c.UA.Family + " " + c.UA.Major + "." + c.UA.Minor;
        }

        public string IPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var Ip = "";
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    Ip = ip.ToString();
                }
                else
                {
                    Ip = ip.ToString();
                }
            }
            return Ip;
        }
    }
}
