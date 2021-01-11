using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemLogs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SysLogs.Data;
using SysLogs.Interfaces;

namespace SystemLogs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SysLogsController : ControllerBase
    {

        private readonly ILogger<SysLogsController> _logger;
        private readonly IManagementService _managementService;
        private readonly ISysLogService _sysLogService;
        public SysLogsController(ILogger<SysLogsController> logger, IManagementService managementService, ISysLogService sysLogService)
        {
            _logger = logger;
            _managementService = managementService;
            _sysLogService = sysLogService;
        }

        //Store any system logs sent here in internal database
        [HttpPut("/logs/")]
        public async Task<IActionResult> PutSystemLog(SystemLog systemLog)
        {
            bool response = _sysLogService.PutSystemLog(systemLog).Result;

            if (response)
            {
                return Ok();
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
    }
}
