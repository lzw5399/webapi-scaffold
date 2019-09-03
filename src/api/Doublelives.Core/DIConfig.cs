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
            ConfigureCos(services, configuration);
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ITencentCosService, TencentCosService>();
            services.AddTransient<IPictureService, PictureService>();
        }

        private static void ConfigureCos(IServiceCollection services, IConfiguration configuration)
        {
            var cosXmlConfig = new CosXmlConfig.Builder()
                .IsHttps(false)
                .SetAppid(configuration["TencentCos:AppId"])
                .SetRegion(configuration["TencentCos:Region"])
                .SetDebugLog(true)
                .Build();
            var cosCredentialProvider = new DefaultQCloudCredentialProvider(
                configuration["TencentCos:SecretId"],
                configuration["TencentCos:SecretKey"],
                Convert.ToInt64(configuration["TencentCos:DurationSecond"]));
            var cosXmlServer = new CosXmlServer(cosXmlConfig, cosCredentialProvider);

            services.AddSingleton<CosXml>(it => cosXmlServer);
        }
    }
}
