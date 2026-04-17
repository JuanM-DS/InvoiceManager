using InvoiceManager.Api.Domain.Errors;

namespace InvoiceManager.Api.Domain.Interfaces
{
    public interface ILogService
    {
        public void Error(string message);
        public void Info(string message);
        public void Error(string message, Exception exception);
        public void Error(AppError appError, Exception exception);
    }
}
