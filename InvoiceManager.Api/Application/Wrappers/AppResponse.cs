using InvoiceManager.Api.Domain.Errors;
using InvoiceManager.Api.Domain.Structs;
using System.Net;

namespace InvoiceManager.Api.Application.Wrappers
{
    public class AppResponse
    {
        public bool Successed { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public List<AppError>? Errors { get; set; }

        public static AppResponse Success()
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

        public static AppResponse<Empty> Empty(this AppResponse response)
            => new() { Successed = response.Successed };

        public static AppResponse<T> WithCode<T>(this AppResponse<T> response, HttpStatusCode httpStatusCode)
            => new() { Successed = response.Successed, HttpStatusCode = httpStatusCode };

        public static AppResponse WithCode(this AppResponse response, HttpStatusCode httpStatusCode)
            => new() { Successed = response.Successed, HttpStatusCode = httpStatusCode };

        public static AppException Trow(this AppResponse appResponse)
            => throw new AppException(appResponse);

        public static AppException Trow(this AppResponse appResponse, Exception exception)
            => throw new AppException(appResponse, exception);
    }
}
