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
            var _logService = scope.ServiceProvider.GetRequiredService<ILogService>();

            var response = new AppResponse();

            if(exception is AppException appEx)
            {
                response = appEx.AppResponse;
            }
            else
            {
                response = Error.Unexpected.InternalServerError();
            }
            httpContext.Response.StatusCode = (int)response.HttpStatusCode;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            _logService.Error(response.Errors!.First(), exception);
            return true;
        }
    }
}
