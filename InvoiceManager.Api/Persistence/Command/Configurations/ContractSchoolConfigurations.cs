using InvoiceManager.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManager.Api.Persistence.Command.Configurations
{
    public class ContractSchoolModelConfigurations : IEntityTypeConfiguration<ContractSchool>
    {
        public void Configure(EntityTypeBuilder<ContractSchool> builder)
        {
            builder.ToTable("ContractSchools");

            builder.HasKey(x => new { x.SchoolId, x.ContractId });

            builder.Property(x => x.SchoolOrder)
                   .IsRequired();

            builder.HasOne(x => x.School)
                   .WithMany(x => x.ContractSchools)
                   .HasForeignKey(x => x.SchoolId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Contract)
                   .WithMany(x => x.ContractSchools)
                   .HasForeignKey(x => x.ContractId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.CreatedBy).HasMaxLength(150).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.UpdatedBy).HasMaxLength(150).IsRequired(false);
        }
    }
}
