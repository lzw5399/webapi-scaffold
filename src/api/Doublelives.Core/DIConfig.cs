using COSXML;
using COSXML.Auth;
using Doublelives.Cos;
using Doublelives.Data;
using Doublelives.Service.Pictures;
using Doublelives.Service.Users;
using Doublelives.Service.WorkContextAccess;
using Microsoft.EntityFrameworkCore;
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
            ConfigurePersistence(services, configuration);
            ConfigureWorkContext(services);
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ITencentCosService, TencentCosService>();
            services.AddTransient<IPictureService, PictureService>();
            services.AddTransient<IUserService, UserService>();
        }

        private static void ConfigurePersistence(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AlbumDbContext>(
                options =>
                {
                    options
                    .UseMySql(
                        configuration.GetConnectionString("Album"),
                        it => it.MigrationsAssembly("Doublelives.Migrations"));
                },
                ServiceLifetime.Transient);
            services
                .AddTransient<IAlbumDbContext, AlbumDbContext>()
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void ConfigureWorkContext(IServiceCollection services)
        {
            services.AddSingleton<IWorkContextAccessor, WorkContextAccessor>();
        }
    }
}
