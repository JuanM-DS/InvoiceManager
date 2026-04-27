using InvoiceManager.Api.Application.Wrappers;
using InvoiceManager.Api.Domain.Structs;
using System.Linq.Expressions;
using System.Net;
using System.Text.Json;

namespace InvoiceManager.Api.Domain.Errors
{
    public record AppError(string Menssage, string? Key = null, string? Property = null)
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

        public static AppResponse<Empty> Badrequest(this AppError error)
            => new() { Successed = false, HttpStatusCode = HttpStatusCode.BadRequest, Errors = [error] };

        public static AppResponse BadRequest(this List<AppError> errors)
            => new() { Successed = false, HttpStatusCode = HttpStatusCode.BadRequest, Errors = errors };

        public static AppResponse<Empty> InternalServerError(this AppError error)
            => new() { Successed = false, HttpStatusCode = HttpStatusCode.InternalServerError, Errors = [error] };
        
        public static string ToString(this AppError error)
            => JsonSerializer.Serialize(error);
    }
}
