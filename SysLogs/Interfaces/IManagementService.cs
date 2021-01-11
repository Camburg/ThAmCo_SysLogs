using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SysLogs.Models;

namespace SysLogs.Interfaces
{
    public interface IManagementService
    {
        //Send unfiltered list of logs from database (Maybe implement pagination or some kind of arbitrary max list size)
        public Task<List<SystemLog>> GetAllSystemLogs();

        //Send Filtered list of logs
        public Task<List<SystemLog>> GetFilteredSystemLogs(Filter filter);
    }
}
