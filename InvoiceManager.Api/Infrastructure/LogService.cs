using InvoiceManager.Api.Application.Interfaces;
using InvoiceManager.Api.Domain.Errors;
using Serilog;

namespace InvoiceManager.Api.Infrastructure
{
    public class LogService : ILogService
    {
        public void Error(string message)
        {
            Log.Error(message);
        }

        public void Error(string message, Exception exception)
        {
            Log.Error(exception, message);
        }

        public void Error(AppError appError, Exception exception)
        {
            Log.Error(exception, appError.ToString());
        }

        public void Info(string message)
        {
            Log.Information(message);
        }
    }
}
