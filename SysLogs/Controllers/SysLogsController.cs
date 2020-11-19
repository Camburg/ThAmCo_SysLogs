using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SystemLogs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SysLogsController : ControllerBase
    {

        private readonly ILogger<SysLogsController> _logger;

        public SysLogsController(ILogger<SysLogsController> logger)
        {
            _logger = logger;
        }

        //Store any system logs sent here in internal database
        [HttpPost]
        public async Task<IActionResult> StoreSystemLog([FromRoute] int componentId, DateTime date, string alertType)
        {
            
        }

        //Send unfiltered list of logs (Maybe implement pagination or some kind of arbitrary max list size)
        [HttpGet]
        public async Task<IActionResult> GetAllSystemLogs()
        {

        }

        //Send list of event logs specifically for the given user
        [HttpGet]
        public async Task<IActionResult> GetUserSystemLogs([FromRoute] string user)
        {

        }

        //Send Filtered list of logs
        [HttpGet]
        public async Task<IActionResult> GetFilteredSystemLogs([FromBody] int componentId, DateTime date, string alertType)
        {

        }
    }
}
