using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.IServices
{
    public interface IAuditService
    {
        void AuditTrail(string username, string description);
        string BrowserName(HttpContext httpContext);
        string IPAddress();

    }
}
