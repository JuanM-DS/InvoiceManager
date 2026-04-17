using InvoiceManager.Api.Domain.Common;

namespace InvoiceManager.Api.Domain.Entities
{
    public class Invoice : BaseEntity, IAuditable
    {
        public int RationsDelivered { get; set; }
        public Guid SchoolId { get; set; }
        public Guid SupplierId { get; set; }
        public Guid ProductId { get; set; }

        public School School { get; set; } = null!;
        public Supplier Supplier { get; set; } = null!;
        public Product Product { get; set; } = null!;

        #region Auditable
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        #endregion
    }
}
