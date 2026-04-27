using InvoiceManager.Api.Application.Interfaces;
using InvoiceManager.Api.Application.Wrappers;
using InvoiceManager.Api.Domain.Errors;
using Microsoft.AspNetCore.Diagnostics;

namespace InvoiceManager.Api.Middlewares
{
    public class GlobalExceptionHandler(IServiceScopeFactory serviceScopeFactory) : IExceptionHandler
    {
        private readonly IServiceScopeFactory serviceScopeFactory = serviceScopeFactory;

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            using var scope = serviceScopeFactory.CreateAsyncScope();
            var logService = scope.ServiceProvider.GetRequiredService<ILogService>();

            if (httpContext.Response.HasStarted)
            {
                logService.Error("Response already started", exception);
                return false;
            }

            AppResponse response;

            if (exception is AppException appEx)
            {
                response = appEx.AppResponse;
            }
            else
            {
                response = Error.Unexpected.InternalServerError();
            }

            httpContext.Response.Clear();
            httpContext.Response.StatusCode = (int)response.HttpStatusCode;
            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

            logService.Error(response.Errors!.First(), exception);

            return true;
        }
    }
}
