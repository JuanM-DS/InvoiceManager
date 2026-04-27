using FluentValidation;

namespace InvoiceManager.Api.Features.Invoices.V1.Commands.Create
{
    public sealed class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleForEach(x => x.Invoices)
                .ChildRules(item =>
                {
                    item.RuleFor(x => x.RationsDelivered)
                        .NotNull()
                        .NotEqual(0);

                    item.RuleFor(x => x.SchoolId)
                        .NotNull()
                        .NotEmpty();

                    item.RuleFor(x => x.SupplierId)
                        .NotNull()
                        .NotEmpty();

                    item.RuleFor(x => x.ProductId)
                        .NotNull()
                        .NotEmpty();
                });
        }
    }
}
