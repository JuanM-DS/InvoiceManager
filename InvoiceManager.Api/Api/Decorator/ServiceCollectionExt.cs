using InvoiceManager.Api.Api.Middlewares;
using InvoiceManager.Api.Domain.Interfaces;
using InvoiceManager.Api.Infrastructure;
using InvoiceManager.Api.Persistence.EFContext;
using InvoiceManager.Api.Persistence.EFContext.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Serilog;

namespace InvoiceManager.Api.Api.Decorator
{
    public static class ServiceCollectionExt
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddExceptionHandler<GlobalExceptionHandler>()
                    .AddDataBaseDescriptors(configuration)
                    .AddScoped<ILogService, LogService>();

            AddSeriLogConfigurations();
            
            return services;
        }

        private static IServiceCollection AddDataBaseDescriptors(this IServiceCollection services, IConfiguration configuration)
        {
            #region configurations
            var connectionString = configuration.GetConnectionString("MainConnectionString");
            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("Connection string not found");
            #endregion

            #region interceptors
            services.AddScoped<IInterceptor, SaveAuditableInterceptor>();
            #endregion

            #region dbcontext
            services.AddDbContext<MainContext>((sp, option) =>
            {
                var interceptors = sp.GetRequiredService<IInterceptor>();

                option.UseSqlServer(connectionString,
                    x => x.MigrationsAssembly(typeof(MainContext).Assembly))
                .AddInterceptors(interceptors);
            });
            #endregion

            return services;
        }

        private static void AddSeriLogConfigurations()
        {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Verbose()
                    .WriteTo.Console()
                    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
                    .CreateLogger();
        }
    }
}
