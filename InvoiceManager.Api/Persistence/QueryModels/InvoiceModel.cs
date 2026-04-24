namespace InvoiceManager.Api.Persistence.QueryModels;

public record InvoiceModel(
    Guid Id,
    int RationsDelivered,
    int InvoiceNumber,
    Guid SchoolId,
    Guid ContractId,
    Guid SupplierId,
    Guid ProductId,
    SchoolModel School,
    ContractModel Contract,
    SupplierModel Supplier,
    ProductModel Product,
    DateTime Created
);
