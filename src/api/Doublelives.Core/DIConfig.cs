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
            ConfigureServices();
        }

        private static void ConfigureServices()
        {
            throw new NotImplementedException();
        }
    }
}
