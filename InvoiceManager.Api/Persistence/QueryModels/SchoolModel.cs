namespace InvoiceManager.Api.Persistence.QueryModels;

public record SchoolModel(
    Guid Id,
    int Code,
    string Name,
    string HeadMasterName,
    string RationsNumber,
    int Order,
    Guid AddressId,
    Guid PhoneNumberId,
    AddressModel Address,
    PhoneNumberModel PhoneNumber
);
