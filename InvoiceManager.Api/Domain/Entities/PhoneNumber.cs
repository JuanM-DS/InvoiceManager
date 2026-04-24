using InvoiceManager.Api.Domain.Common;
using InvoiceManager.Api.Domain.Enumerables;

namespace InvoiceManager.Api.Domain.Entities
{
    public class PhoneNumber : BaseEntity, IAuditable
    {
        public int Number { get; set; }
        public PhoneNumberType Type { get; set; }

        #region Auditable
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        #endregion
    }
}
