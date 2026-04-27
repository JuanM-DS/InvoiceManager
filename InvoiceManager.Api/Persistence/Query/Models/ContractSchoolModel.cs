namespace InvoiceManager.Api.Persistence.QueryContext.QueryModels;

public record ContractSchoolModel(
    int SchoolOrder,
    Guid ContractId,
    Guid SchoolId,
    ContractModel Contract,
    SchoolModel School
);
