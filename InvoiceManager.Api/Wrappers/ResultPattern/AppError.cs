using System.Linq.Expressions;
using System.Net;

namespace InvoiceManager.Api.Wrappers.ResultPattern
{
    public record AppError(string Menssage, string? Property = null)
    {
        public static AppError Create(string Menssage)
            => new(Menssage);
    }

    public static class AppErrorExt
    {
        public static AppError For(this AppError AppError, string PropName)
            => AppError with { Property = PropName };

        public static AppError For<T>(this AppError error, Expression<Func<T, object>> expression)
        {
            var body = expression.Body;

            if (body is UnaryExpression unary)
                body = unary.Operand;

            if (body is not MemberExpression member)
                return error with { Property = "Invalid property expression" };

            return error with { Property = member.Member.Name };
        }

        public static AppResponse Badrequest(this AppError error)
            => new() { Successed = false, HttpStatusCode = HttpStatusCode.BadRequest, Errors = [error] };

        public static AppResponse Badrequest(this List<AppError> errors)
            => new() { Successed = false, HttpStatusCode = HttpStatusCode.BadRequest, Errors = errors };

        public static AppResponse InternalServerError(this AppError error)
            => new() { Successed = false, HttpStatusCode = HttpStatusCode.InternalServerError, Errors = [error] };
    }
}
