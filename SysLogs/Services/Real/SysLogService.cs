using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemLogs.Models;
using SysLogs.Data;
using SysLogs.Interfaces;

namespace SysLogs.Services.Real
{
    public class SysLogService : ISysLogService
    {
        private readonly SysLogsDbContext _context;

        SysLogService(SysLogsDbContext context)
        {
            _context = context;
        }

        //Store any system logs sent here in internal database
        public async Task<bool> PutSystemLog(SystemLog systemLog)
        {
            systemLog.ComponentName = systemLog.ComponentName.ToLower();
            if (CheckValidComponent(systemLog.ComponentName))
            {
                _context.Add(systemLog);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckValidComponent(string component)
        {
            var validComponents = new List<string>
            {
                "accounts",
                "profile",
                "orders",
                "invoices",
                "catalogue",
                "reviews",
                "stockmanagement",
                "resales",
                "management",
                "systemlogs"
            };
            return validComponents.Contains(component);
        }
    }
}
