using FluentValidation;
using InvoiceManager.Api.Application.Wrappers;
using InvoiceManager.Api.Domain.Errors;
using MediatR;

namespace InvoiceManager.Api.Application.Behaviors
{
    public class ValidatorBehavior<TRequest, TResponse>(
        IEnumerable<IValidator<TRequest>> validators
    ) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : AppResponse
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (!_validators.Any())
                return await next(cancellationToken);

            var context = new ValidationContext<TRequest>(request);

            var results = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, cancellationToken))
            );

            var failures = results
                .SelectMany(r => r.Errors)
                .Where(e => e != null)
                .ToList();

            if (failures.Count == 0)
                return await next(cancellationToken);

            var errors = failures
                    .Select(x => AppError
                        .Create(x.ErrorMessage)
                        .For(x.PropertyName))
                    .ToList();

            return (TResponse)errors.BadRequest();
        }
    }
}