namespace InvoiceManager.Api.Persistence.QueryContext.QueryModels;

public record AddressModel(
    Guid Id,
    string HauseNumber,
    string Street,
    string SubSector,
    string Sector,
    string Municipaly,
    string Province,
    string Country
);
