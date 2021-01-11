using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SysLogs.Models;
using Microsoft.AspNetCore.Mvc;
using SysLogs.Data;
using SysLogs.Interfaces;

namespace SysLogs.Services.Fake
{
    public class FakeManagementService : IManagementService
    {
        //Send unfiltered list of logs from database (Maybe implement pagination or some kind of arbitrary max list size)
        public async Task<List<SystemLog>> GetAllSystemLogs()
        {

            return null;
        }

        //Send Filtered list of logs
        public async Task<List<SystemLog>> GetFilteredSystemLogs(Filter filter)
        {
            return null;
        }
    }
}
