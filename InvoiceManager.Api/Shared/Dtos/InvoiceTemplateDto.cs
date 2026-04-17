namespace InvoiceManager.Api.Shared.Dtos
{
    public record InvoiceTemplateDto(
        int RationsDelivered,
        SchoolTemplateDto School,
        Supplier Supplier,
        ProductTemplateDto ProductTemplateDto
        );

    public record Supplier(
        string Name,
        string Email,
        string TaxNumber,
        AddressTemplateDto Address,
        List<PhoneTemplateDto> PhoneNumbers);
    
    public record SchoolTemplateDto(
        int Code,
        string Name,
        string HeadMasterName,
        string RationsNumber,
        PhoneTemplateDto Phone,
        AddressTemplateDto Address);

    public record PhoneTemplateDto(
        int Number,
        string Type
        );

    public record ProductTemplateDto(
        string Name,
        decimal Price
        );

    public record AddressTemplateDto
    (
        string HauseNumber,
        string Street,
        string SubSector,
        string Sector,
        string Municipaly,
        string Province,
        string Country
    );
}
