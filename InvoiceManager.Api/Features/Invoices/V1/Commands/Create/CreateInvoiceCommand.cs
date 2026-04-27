using InvoiceManager.Api.Application.Wrappers;
using InvoiceManager.Api.Domain.Structs;
using MediatR;

namespace InvoiceManager.Api.Features.Invoices.V1.Commands.Create
{
    public sealed record CreateInvoiceCommand(List<CreateInvoiceItem> Invoices) : IRequest<AppResponse<Empty>>;
    public sealed record CreateInvoiceItem(
            int RationsDelivered,
            DateTime DeliveredAt,
            Guid SchoolId,
            Guid SupplierId,
            Guid ProductId,
            Guid ContractId);
}
