using InvoiceManager.Api.Domain.Common;

namespace InvoiceManager.Api.Domain.Entities
{
    public class Address : BaseEntity, IAuditable
    {
        public string HauseNumber { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string SubSector { get; set; } = string.Empty;
        public string Sector { get; set; } = string.Empty;
        public string Municipaly { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        #region Auditable
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        #endregion
    }
}
