namespace InvoiceManager.Api.Persistence.QueryContext.QueryModels;

public record InvoiceModel(
    Guid Id,
    int RationsDelivered,
    int InvoiceNumber,
    DateTime DeliveredAt,
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
