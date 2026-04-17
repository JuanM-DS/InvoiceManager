using InvoiceManager.Api.Domain.Common;

namespace InvoiceManager.Api.Domain.Entities
{
    public class Product : BaseEntity, IAuditable
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        #region Auditable
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        #endregion
    }
}
