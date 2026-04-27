namespace InvoiceManager.Api.Domain.Enumerables
{
    public enum ProcurementType
    {
        PublicTender = 1,       // Licitación pública
        MinorPurchase = 2,      // Compra menor
        PriceComparison = 3,    // Comparación de precios
        Exception = 4           // Excepción
    }
}
