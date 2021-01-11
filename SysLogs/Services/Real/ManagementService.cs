using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SysLogs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SysLogs.Data;
using SysLogs.Enums;
using SysLogs.Interfaces;

namespace SysLogs.Services.Real 
{
    public class ManagementService : IManagementService
    {
        private readonly SysLogsDbContext _context;

        public ManagementService(SysLogsDbContext context)
        {
            _context = context;
        }

        //Send unfiltered list of logs from database (Maybe implement pagination or some kind of arbitrary max list size)
        public async Task<List<SystemLog>> GetAllSystemLogs()
        {
            var systemLogs = await _context.SystemLogs.ToListAsync();
            return systemLogs;
        }

        //Send Filtered list of logs
        public async Task<List<SystemLog>> GetFilteredSystemLogs(Filter filter)
        {
            var systemLogs = await GetAllSystemLogs();
            if (filter.Date != default)
            {
                systemLogs = systemLogs.Where(x => x.Date == filter.Date).ToList();
            }
            if (filter.ComponentName != null)
            {
                systemLogs = systemLogs.Where(x => x.ComponentName.Equals(filter.ComponentName)).ToList();
            }
            if (filter.AlertType != AlertType.NONE)
            {
                systemLogs = systemLogs.Where(x => x.AlertType == filter.AlertType).ToList();
            }
            if (filter.Role != null)
            {
                systemLogs = systemLogs.Where(x => x.Role.Equals(filter.Role)).ToList();
            }
            return systemLogs;
        }
    }
}
