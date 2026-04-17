using InvoiceManager.Api.Persistence.EFContext;
using InvoiceManager.Api.Persistence.EFContext.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace InvoiceManager.Api.Decorator.ServicesCollection
{
    public static class ServiceCollectionExt
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataDescriptors(configuration);
            return services;
        }

        private static IServiceCollection AddDataDescriptors(this IServiceCollection services, IConfiguration configuration)
        {
            #region configurations
            var connectionString = configuration.GetConnectionString("MainConnectionString");
            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("Connection string not found");
            #endregion

            #region interceptors
            services.AddScoped<IInterceptor,SaveAuditableInterceptor>();
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
    }
}
