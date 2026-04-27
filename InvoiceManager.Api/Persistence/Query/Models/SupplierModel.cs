namespace InvoiceManager.Api.Persistence.QueryContext.QueryModels;

public record SupplierModel(
    Guid Id,
    string Name,
    string Email,
    string TaxNumber,
    Guid AddressId,
    AddressModel Address,
    IReadOnlyCollection<PhoneNumberModel> PhoneNumbers
);
