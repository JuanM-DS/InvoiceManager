using InvoiceManager.Api.Domain.Common;
using InvoiceManager.Api.Domain.Enumerables;

namespace InvoiceManager.Api.Domain.Entities
{
    public class Organization : BaseEntity, IAuditable
    {
        public string Name { get; set; } = string.Empty;
        public OrganizationType OrganizationType { get; set; }
        public ContractStatus ContractStatus { get; set; }

        #region Auditable
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        #endregion
    }
}
