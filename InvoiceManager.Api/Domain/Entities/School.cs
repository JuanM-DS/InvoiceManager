using InvoiceManager.Api.Domain.Common;

namespace InvoiceManager.Api.Domain.Entities
{
    public class School : BaseEntity, IAuditable
    {
        public int Code { get; set; }
        public string Name { get; set; } = string.Empty;
        public string HeadMasterName { get; set; } = string.Empty;
        public int RationsNumber { get; set; }
        public Guid AddressId { get; set; }
        public Guid PhoneNumberId { get; set; }
        public PhoneNumber PhoneNumber { get; set; } = null!;
        public Address Address { get; set; } = null!;
        public ICollection<Contract> Contracts { get; set; } = [];
        public ICollection<ContractSchool> ContractSchools { get; set; } = [];

        #region Auditable
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        #endregion
    }
}
