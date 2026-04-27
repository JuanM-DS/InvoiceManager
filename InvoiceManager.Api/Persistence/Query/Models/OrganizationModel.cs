using InvoiceManager.Api.Domain.Enumerables;

namespace InvoiceManager.Api.Persistence.QueryContext.QueryModels;

public record OrganizationModel(
    Guid Id,
    string Name,
    OrganizationType OrganizationType,
    IReadOnlyCollection<ProcurementProcessModel> ProcurementProcessModels
);
