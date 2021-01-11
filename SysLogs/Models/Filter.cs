﻿using SysLogs.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SysLogs.Models
{
    public class Filter
    {
        public string ComponentName { get; set; }
        public string Role { get; set; }
        public DateTime Date { get; set; }
        public AlertType AlertType { get; set; }
    }
}
