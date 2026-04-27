using InvoiceManager.Api.Application.Wrappers;
using InvoiceManager.Api.Persistence.QueryContext.QueryModels;
using MediatR;

namespace InvoiceManager.Api.Features.Invoices.V1.Querys.GetAll
{
    public record Query(
        DateTime? DeliveredSince,
        DateTime? DeliveredTo,
        int? InvoiceNumberSince,
        int? InvoiceNumberTo,
        Guid? ProductId,
        Guid? SchoolId,
        Guid? ContractId,
        string? Order,
        bool OrderDesc
    ) : IRequest<AppResponse<List<InvoiceModel>>>;
}
