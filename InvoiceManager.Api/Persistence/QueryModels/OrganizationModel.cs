using InvoiceManager.Api.Domain.Enumerables;

namespace InvoiceManager.Api.Persistence.QueryModels;

public record OrganizationModel(
    Guid Id,
    string Name,
    OrganizationType OrganizationType,
    ContractStatus ContractStatus
);
