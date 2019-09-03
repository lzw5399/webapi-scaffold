using COSXML;
using COSXML.Auth;
using Doublelives.Cos;
using Doublelives.Service.Pictures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doublelives.Core
{
    public static class DIConfig
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            ConfigureServices(services, configuration);
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ITencentCosService, TencentCosService>();
            services.AddTransient<IPictureService, PictureService>();
        }
    }
}
