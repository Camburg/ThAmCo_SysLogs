using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SysLogs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SysLogs.Data;
using SysLogs.Interfaces;

namespace SysLogs.Controllers
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
        [HttpPut("logs")]
        public async Task<IActionResult> PutSystemLog([FromBody] SystemLog systemLog)
        {
            bool response = await _sysLogService.PutSystemLog(systemLog);

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
        [HttpGet("logs")]
        public async Task<IActionResult> GetAllSystemLogs()
        {
            List<SystemLog> response = await _managementService.GetAllSystemLogs();

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        //Send Filtered list of logs
        [HttpGet("logs/filtered")]
        public async Task<IActionResult> GetFilteredSystemLogs(Filter filter)
        {
            List<SystemLog> response = await _managementService.GetFilteredSystemLogs(filter);

            if (response.Any())
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
