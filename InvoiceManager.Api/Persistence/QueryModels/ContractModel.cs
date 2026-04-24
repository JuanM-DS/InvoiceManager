namespace InvoiceManager.Api.Persistence.QueryModels;

public record ContractModel(
    Guid Id,
    string Name,
    Guid OrganizationId,
    OrganizationModel Organization
);
