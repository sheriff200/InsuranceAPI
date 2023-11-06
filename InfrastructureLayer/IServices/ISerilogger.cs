using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.IServices
{
    public interface ISerilogger
    {
        void LogRequest(string message, bool isError, string directory);
    }
}
