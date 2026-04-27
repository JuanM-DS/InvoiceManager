using InvoiceManager.Api.Domain.Enumerables;

namespace InvoiceManager.Api.Persistence.QueryContext.QueryModels
{
    public record ProcurementProcessModel(
        Guid Id,
        string Name,
        ProcurementType Type,
        Guid OrganizationId,
        OrganizationModel Organization,
        IReadOnlyCollection<ContractModel> Contracts
    );
}
