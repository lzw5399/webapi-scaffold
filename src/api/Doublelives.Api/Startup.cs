using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doublelives.Core;
using Doublelives.Shared.ConfigModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Doublelives.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            DIConfig.Configure(services, Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "doublelives album", Version = "v1.0" });
            });

            services.Configure<TencentCosOptions>(Configuration.GetSection("TencentCos"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory
                .AddSentry(options =>
                {
                    options.Dsn = Configuration["SentryClientKey"];
                    options.Environment = env.EnvironmentName;
                    options.MinimumEventLevel = LogLevel.Error;
                    options.Debug = env.IsDevelopment();
                });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "doublelives album V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();
        }
    }
}
