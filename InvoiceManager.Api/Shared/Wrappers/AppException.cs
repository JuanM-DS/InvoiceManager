namespace InvoiceManager.Api.Shared.Wrappers
{
    public class AppException(AppResponse appResponse, Exception? innerException = null) : Exception(innerException?.Message, innerException)
    {
        public AppResponse AppResponse { get; set; } = appResponse;
    }
}
