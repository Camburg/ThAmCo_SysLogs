using Management.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemLogs.Models
{
    public class SystemLog
    {
        public Guid Id { get; set; }
        public string ComponentName { get; set; }
        public string Details { get; set; }
        public string Role { get; set; }
        public DateTime Date { get; set; }
        public AlertType AlertType { get; set; }
    }
}
