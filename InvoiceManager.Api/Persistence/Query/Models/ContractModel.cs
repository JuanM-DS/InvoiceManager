namespace InvoiceManager.Api.Persistence.QueryContext.QueryModels;

public record ContractModel(
    Guid Id,
    string Name,
    Guid OrganizationId,
    ProcurementProcessModel ProcurementProcessModel,
    IReadOnlyCollection<SchoolModel> SchoolModels,
    IReadOnlyCollection<ContractSchoolModel> ContractSchoolModels
);
