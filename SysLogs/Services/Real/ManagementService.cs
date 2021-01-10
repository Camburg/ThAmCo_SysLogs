using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemLogs.Models;
using Microsoft.AspNetCore.Mvc;
using SysLogs.Data;
using SysLogs.Interfaces;

namespace SysLogs.Services.Real 
{
    public class ManagementService : IManagementService
    {
        private readonly SysLogsDbContext _context;

        ManagementService(SysLogsDbContext context)
        {
            _context = context;
        }

        //Send unfiltered list of logs from database (Maybe implement pagination or some kind of arbitrary max list size)
        public async Task<List<SystemLog>> GetAllSystemLogs()
        {

            return null;
        }

        //Send list of event logs specifically for the given user
        public async Task<List<SystemLog>> GetAllUserSystemLogs(string user)
        {
            return null;
        }

        //Send Filtered list of logs
        public async Task<List<SystemLog>> GetFilteredSystemLogs(int componentId, DateTime date, string alertType)
        {
            return null;
        }
    }
}
