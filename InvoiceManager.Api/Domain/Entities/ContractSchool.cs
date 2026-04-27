using InvoiceManager.Api.Domain.Common;

namespace InvoiceManager.Api.Domain.Entities
{
    public class ContractSchool : IAuditable
    {
        public int SchoolOrder { get; set; }
        public Guid ContractId { get; set; }
        public Guid SchoolId { get; set; }

        public Contract Contract { get; set; } = null!;
        public School School { get; set; } = null!;

        #region Auditable
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        #endregion
    }
}
