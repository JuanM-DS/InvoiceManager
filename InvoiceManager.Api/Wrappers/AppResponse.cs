using InvoiceManager.Api.Domain.Errors;
using System.Net;

namespace InvoiceManager.Api.Wrappers
{
    public class AppResponse
    {
        public bool Successed { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public List<AppError>? Errors { get; set; }

        public static AppResponse Ok()
            => new() { Successed = true, HttpStatusCode = HttpStatusCode.OK };
    }

    public class AppResponse<T> : AppResponse
    {
        public T Data { get; set; } = default!;
    }

    public static class AppResponseExt
    {
        public static AppResponse<T> WithData<T>(this AppResponse response, T data)
            => new() { Successed = response.Successed, HttpStatusCode = response.HttpStatusCode, Data = data };

        public static AppResponse WithCode(this AppResponse response, HttpStatusCode httpStatusCode)
            => new() { Successed = response.Successed, HttpStatusCode = httpStatusCode };

        public static AppException Trow(this AppResponse appResponse)
            => throw new AppException(appResponse);

        public static AppException Trow(this AppResponse appResponse, Exception exception)
            => throw new AppException(appResponse, exception);
    }
}
