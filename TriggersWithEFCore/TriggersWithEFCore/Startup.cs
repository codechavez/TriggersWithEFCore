using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriggersWithEFCore.Persistence;

namespace TriggersWithEFCore
{
    public class Startup
    {
        public static readonly ILoggerFactory _sqlLogger = LoggerFactory.Create(builder => builder.AddConsole().AddDebug());

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<TriggersEFCoreContext>(options =>
            {
                options.UseLoggerFactory(_sqlLogger);
                options.UseInMemoryDatabase($"tempDbTriggers");
                options.UseTriggers(triggers =>
                {
                    triggers.AddTrigger<SetCreatedDate>();
                    triggers.AddTrigger<AfterCreateUserBirthday>();
                });
            });

            // Rest of your injections/services

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
