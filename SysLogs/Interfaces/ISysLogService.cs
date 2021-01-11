using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SysLogs.Models;

namespace SysLogs.Interfaces
{
    public interface ISysLogService
    {
        public Task<bool> PutSystemLog(SystemLog systemLog);
    }
}
