using InvoiceManager.Api.Domain.Errors;
using InvoiceManager.Api.Domain.Interfaces;
using InvoiceManager.Api.Shared.Wrappers;
using Microsoft.AspNetCore.Diagnostics;

namespace InvoiceManager.Api.Api.Middlewares
{
    public class GlobalExceptionHandler(ILogService logService) : IExceptionHandler
    {
        private readonly ILogService _logService = logService;

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
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
