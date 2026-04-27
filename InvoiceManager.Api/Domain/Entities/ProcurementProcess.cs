using InvoiceManager.Api.Domain.Common;
using InvoiceManager.Api.Domain.Enumerables;

namespace InvoiceManager.Api.Domain.Entities
{
    public class ProcurementProcess : BaseEntity, IAuditable
    {
        public string Name { get; set; } = string.Empty;
        public ProcurementType Type { get; set; }

        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; } = null!;

        public ICollection<Contract> Contracts { get; set; } = [];

        #region Auditable
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        #endregion
    }
}
