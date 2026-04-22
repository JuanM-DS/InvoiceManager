using InvoiceManager.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManager.Api.Persistence.EFContext.Configurations
{
    public class ContractConfigurations : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.ToTable("Contract");
            builder.HasKey(x => x.Id)
                   .IsClustered();
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Nombre).HasMaxLength(150).IsRequired();

            builder.HasOne(x => x.Organization)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.CreatedBy).HasMaxLength(150).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.UpdatedBy).HasMaxLength(150).IsRequired(false);
        }
    }
}
