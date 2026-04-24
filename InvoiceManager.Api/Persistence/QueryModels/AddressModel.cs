namespace InvoiceManager.Api.Persistence.QueryModels;

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
