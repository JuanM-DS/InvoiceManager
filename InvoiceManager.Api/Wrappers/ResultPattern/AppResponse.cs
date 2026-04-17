using System.Net;

namespace InvoiceManager.Api.Wrappers.ResultPattern
{
    public class AppResponse
    {
        public bool Successed { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public List<AppError>? Errors { get; set; }

        public static AppResponse Ok(AppError error)
            => new() { Successed = true, HttpStatusCode = HttpStatusCode.OK };
    }

    public class AppResponse<T> : AppResponse
    {
        public T Data { get; set; } = default!;
    }

    public static class AppResponseExt
    {
        public static AppResponse<T> WithData<T>(this AppResponse response, T data)
            => new() { Successed = true, HttpStatusCode = HttpStatusCode.OK, Data = data };
    }
}
