using Asp.Versioning;
using InvoiceManager.Api.Features.Abstractions;

namespace InvoiceManager.Api.Decorator
{
    public static class AppRegistrationExt
    {
        public static WebApplication RegisterApp(this WebApplication app)
        {
            app.RegisterEndPoints();

            return app;
        }

        private static WebApplication RegisterEndPoints(this WebApplication app)
        {
            var apiVersioningSet = app.NewApiVersionSet()
                                      .HasApiVersion(new ApiVersion(1.0))
                                      .ReportApiVersions()
                                      .Build();

            var group = app.MapGroup("Api/V{version:apiversion}")
                           .WithApiVersionSet(apiVersioningSet);

            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider.GetServices<IEndpoint>();

            foreach (var item in services)
            {
                item.MapEndpoint(group);
            }

            return app;
        }
    }
}
