using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemLogs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SysLogs.Data;

namespace SystemLogs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SysLogsController : ControllerBase
    {

        private readonly ILogger<SysLogsController> _logger;
        private readonly SysLogsDbContext _context;

        public SysLogsController(ILogger<SysLogsController> logger, SysLogsDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        //Store any system logs sent here in internal database
        [HttpPut("/logs/")]
        public async Task<IActionResult> PutSystemLog(SystemLog systemLog)
        {
            systemLog.ComponentName = systemLog.ComponentName.ToLower();
            if (CheckValidComponent(systemLog.ComponentName))
            {
                if (ModelState.IsValid)
                {
                    _context.Add(systemLog);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        //Send unfiltered list of logs from database (Maybe implement pagination or some kind of arbitrary max list size)
        [HttpGet("/logs/")]
        public async Task<IActionResult> GetAllSystemLogs()
        {

            return null;
        }

        //Send list of event logs specifically for the given user
        [HttpGet("/logs/user/{user}")]
        public async Task<IActionResult> GetAllUserSystemLogs([FromRoute] string user)
        {
            return null;
        }

        //Send Filtered list of logs
        [HttpGet("/logs/get/{componentId}/{date}/{alertType}")]
        public async Task<IActionResult> GetFilteredSystemLogs(int componentId, DateTime date, string alertType)
        {
            return null;
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
