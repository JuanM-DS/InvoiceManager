using InvoiceManager.Api.Domain.Enumerables;

namespace InvoiceManager.Api.Persistence.QueryContext.QueryModels;

public record PhoneNumberModel(
    Guid Id,
    string Number,
    PhoneNumberType Type,
    OwnerType OwnerType,
    Guid OwnerId
);
