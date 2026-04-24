using InvoiceManager.Api.Api.Middlewares;
using InvoiceManager.Api.Domain.Interfaces;
using InvoiceManager.Api.Infrastructure;
using InvoiceManager.Api.Persistence.DbContexts;
using InvoiceManager.Api.Persistence.Interceptors;
using InvoiceManager.Api.Persistence.QueryDbContext;
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
            var readConnectionString = configuration.GetConnectionString("ReadConnectionString");
            var writeConnectionString = configuration.GetConnectionString("WriteConnectionString");
            if (string.IsNullOrEmpty(readConnectionString) || string.IsNullOrEmpty(writeConnectionString))
                throw new Exception("Connection string not found");
            #endregion

            #region interceptors
            services.AddScoped<IInterceptor, SaveAuditableInterceptor>();
            #endregion

            #region dbcontexts
            services.AddDbContextPool<CommandDbContext>((sp, option) =>
            {
                var interceptors = sp.GetRequiredService<IInterceptor>();

                option.UseSqlServer(writeConnectionString,
                    x => x.MigrationsAssembly(typeof(CommandDbContext).Assembly))
                .AddInterceptors(interceptors);
            });

            services.AddDbContextPool<QueryDbContext>(options =>
            {
                options.UseSqlServer(readConnectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .EnableDetailedErrors(false)
                .EnableSensitiveDataLogging(false);
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
