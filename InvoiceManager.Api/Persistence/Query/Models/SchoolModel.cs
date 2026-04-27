namespace InvoiceManager.Api.Persistence.QueryContext.QueryModels;

public record SchoolModel(
    Guid Id,
    int Code,
    string Name,
    string HeadMasterName,
    int RationsNumber,
    Guid AddressId,
    Guid PhoneNumberId,
    AddressModel Address,
    PhoneNumberModel PhoneNumber,
    IReadOnlyCollection<ContractModel> ContractModels,
    IReadOnlyCollection<ContractSchoolModel> ContractSchoolModels
);
