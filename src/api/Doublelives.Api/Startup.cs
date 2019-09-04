using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Doublelives.Api.AutoMapper;
using Doublelives.Core;
using Doublelives.Core.Filters;
using Doublelives.Shared.ConfigModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Converters;
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

            services.AddAutoMapper(c =>
            {
                c.AddProfile(new ResponseProfile());
            }, typeof(Startup));

            services
                .AddMvc(options =>
                {
                    options.Filters.Add<GlobalExceptionFilter>();
                })
                .AddJsonOptions(options =>
                {
                    // 配置string转enum
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    // 避免循环依赖
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    // 配置序列化时时间格式
                    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
