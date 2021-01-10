using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemLogs.Models;

namespace SysLogs.Interfaces
{
    public interface IManagementService
    {
        //Send unfiltered list of logs from database (Maybe implement pagination or some kind of arbitrary max list size)
        public Task<List<SystemLog>> GetAllSystemLogs();

        //Send list of event logs specifically for the given user
        public Task<List<SystemLog>> GetAllUserSystemLogs(string user);

        //Send Filtered list of logs
        public Task<List<SystemLog>> GetFilteredSystemLogs(int componentId, DateTime date, string alertType);
    }
}
