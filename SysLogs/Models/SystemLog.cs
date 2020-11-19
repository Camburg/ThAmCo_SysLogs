using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemLogs.Models
{
    public class SystemLog
    {
        public int LogId { get; set; }
        public int ComponentId { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }
        public string AlertType { get; set; }
    }
}
