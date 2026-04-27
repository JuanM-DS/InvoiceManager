using InvoiceManager.Api.Persistence.QueryContext.QueryModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManager.Api.Persistence.Query.Configurations
{
    public class ContractSchoolModelConfigurations : IEntityTypeConfiguration<ContractSchoolModel>
    {
        public void Configure(EntityTypeBuilder<ContractSchoolModel> builder)
        {
            builder.ToTable("ContractSchools");

            builder.HasKey(x => new { x.SchoolId, x.ContractId });

            builder.HasOne(x => x.School)
                   .WithMany(x => x.ContractSchoolModels)
                   .HasForeignKey(x => x)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Contract)
                   .WithMany(x => x.ContractSchoolModels)
                   .HasForeignKey(x => x.ContractId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
