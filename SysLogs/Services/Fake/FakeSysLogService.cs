using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SysLogs.Interfaces;
using SysLogs.Models;

namespace SysLogs.Services.Fake
{
    public class FakeSysLogService : ISysLogService
    {
        public Task<bool> PutSystemLog(SystemLog systemLog)
        {
            throw new NotImplementedException();
        }
    }
}
