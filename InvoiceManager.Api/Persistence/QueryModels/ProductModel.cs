namespace InvoiceManager.Api.Persistence.QueryModels;

public record ProductModel(
    Guid Id,
    string Name,
    decimal Price
);