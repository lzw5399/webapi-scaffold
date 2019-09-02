using COSXML;
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
            throw new NotImplementedException();
        }

        private static void ConfigureCos(IServiceCollection services, IConfiguration configuration)
        {
            var cosXmlConfig = new CosXmlConfig.Builder()
                .IsHttps(false)
                .SetAppid(configuration["TencentCos:AppId"])
                .SetRegion(configuration["TencentCos:Region"])
                .SetDebugLog(true)
                .Build();
        }
    }
}
