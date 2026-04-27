using InvoiceManager.Api.Domain.Common;
using InvoiceManager.Api.Domain.Enumerables;

namespace InvoiceManager.Api.Domain.Entities
{
    public class Contract : BaseEntity, IAuditable
    {
        public string Name { get; set; } = string.Empty;
        public ContractStatus ContractStatus { get; set; }
        public Guid ProcurementProcessId { get; set; }
        public Guid SupplierId { get; set; }

        public Supplier Supplier { get; set; } = null!;
        public ProcurementProcess ProcurementProcess{ get; set; } = null!;
        public ICollection<School> Schools { get; set; } = [];
        public ICollection<ContractSchool> ContractSchools { get; set; } = [];

        #region Auditable
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        #endregion
    }
}
