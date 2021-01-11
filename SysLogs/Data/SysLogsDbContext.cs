using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SysLogs.Models;

namespace SysLogs.Data
{
    public class SysLogsDbContext : DbContext
    {
        public DbSet<SystemLog> SystemLogs { get; set; }

        public SysLogsDbContext(DbContextOptions<SysLogsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
