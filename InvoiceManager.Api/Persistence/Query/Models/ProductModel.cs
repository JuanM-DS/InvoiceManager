namespace InvoiceManager.Api.Persistence.QueryContext.QueryModels;

public record ProductModel(
    Guid Id,
    string Name,
    decimal Price
);