namespace InvoiceManager.Api.Persistence.QueryModels;

public record SupplierModel(
    Guid Id,
    string Name,
    string Email,
    string TaxNumber,
    Guid AddressId,
    AddressModel Address,
    ICollection<PhoneNumberModel> PhoneNumbers
);
