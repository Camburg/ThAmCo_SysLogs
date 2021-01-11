using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SysLogs.Data;
using SysLogs.Interfaces;
using SysLogs.Services;
using SysLogs.Services.Fake;
using SysLogs.Services.Real;

namespace SysLogs
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SysLogsDbContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("SysLogsDbConnectionString"));
            });
            services.AddSwaggerGen();

            if (Environment.IsDevelopment())
            {
                AddMockServices(services);
            }
            else
            {
                AddRealServices(services);
            }

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "ThAmCo SysLogs API"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddMockServices(IServiceCollection services)
        {
            services.AddSingleton<IManagementService, FakeManagementService>();
            services.AddSingleton<ISysLogService, FakeSysLogService>();
        }
        private void AddRealServices(IServiceCollection services)
        {
            services.AddScoped<IManagementService, ManagementService>();
            services.AddScoped<ISysLogService, SysLogService>();
        }
    }
}
