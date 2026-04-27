using FluentValidation;
using InvoiceManager.Api.Application.Behaviors;
using InvoiceManager.Api.Application.Interfaces;
using InvoiceManager.Api.Extensions;
using InvoiceManager.Api.Infrastructure;
using InvoiceManager.Api.Middlewares;
using InvoiceManager.Api.Persistence.Command.Context;
using InvoiceManager.Api.Persistence.Interceptors;
using InvoiceManager.Api.Persistence.Query.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Serilog;

namespace InvoiceManager.Api.Extensions
{
    public static class ServiceCollectionExt
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddExceptionHandler<GlobalExceptionHandler>()
                    .AddDataBaseDescriptors(configuration)
                    .AddScoped<ILogService, LogService>()
                    .AddValidations()
                    .AddMediatR();
            
            return services;
        }
        public static WebApplicationBuilder AddWebApplicationBuilderExt(this WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((context, config) =>
            {
                config
                    .MinimumLevel.Verbose()
                    .WriteTo.Console()
                    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day);
            });
            return builder;
        }
        private static IServiceCollection AddDataBaseDescriptors(this IServiceCollection services, IConfiguration configuration)
        {
            #region configurations
            var QueryConnectionString = configuration.GetConnectionString("QueryConnectionString");
            var CommandConnectionString = configuration.GetConnectionString("CommnadConnectionString");
            if (string.IsNullOrEmpty(QueryConnectionString) || string.IsNullOrEmpty(CommandConnectionString))
                throw new Exception("Connection string not found");
            #endregion

            #region interceptors
            services.AddScoped<IInterceptor, SaveAuditableInterceptor>();
            #endregion

            #region dbcontexts
            services.AddDbContext<CommandDbContext>((sp, option) =>
            {
                var interceptors = sp.GetServices<IInterceptor>();

                option.UseSqlServer(CommandConnectionString,
                x => x.MigrationsAssembly(typeof(CommandDbContext).Assembly))
                .AddInterceptors(interceptors);
            });

            services.AddDbContextPool<QueryDbContext>(options =>
            {
                options.UseSqlServer(QueryConnectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .EnableDetailedErrors(false)
                .EnableSensitiveDataLogging(false);
            });
            #endregion

            return services;
        }
        private static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(confi =>
            {
                confi.RegisterServicesFromAssemblyContaining<Program>();
                confi.AddOpenBehavior(typeof(ValidatorBehavior<,>));
            });

            return services;
        }
        private static IServiceCollection AddValidations(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining(typeof(Program));

            return services;
        }
    }
}
