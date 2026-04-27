using InvoiceManager.Api.Domain.Entities;

namespace InvoiceManager.Api.Features.Invoices.V1.Commands.Create
{
    public static class Mapper
    {
        public static List<Invoice> Map(this List<InvoiceItem> createInvoices)
            => createInvoices.Select(x => new Invoice
            {
                RationsDelivered = x.RationsDelivered,
                DeliveredAt = x.DeliveredAt,
                SchoolId = x.SchoolId,
                SupplierId = x.SchoolId,
                ProductId = x.SchoolId,
                ContractId = x.ContractId
            }).ToList();
    }
}
