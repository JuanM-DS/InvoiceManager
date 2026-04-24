using InvoiceManager.Api.Domain.Enumerables;

namespace InvoiceManager.Api.Persistence.QueryModels;

public record PhoneNumberModel(
    Guid Id,
    int Number,
    PhoneNumberType Type
);
