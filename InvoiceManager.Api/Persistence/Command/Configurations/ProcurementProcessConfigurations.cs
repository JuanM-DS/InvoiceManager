using InvoiceManager.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManager.Api.Persistence.Command.Configurations
{
    public class ProcurementProcessConfigurationsModel : IEntityTypeConfiguration<ProcurementProcess>
    {
        public void Configure(EntityTypeBuilder<ProcurementProcess> builder)
        {
            builder.ToTable("ProcurementProcesses");

            builder.HasKey(x => x.Id)
                   .IsClustered();

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.HasIndex(x => x.Name).IsUnique();

            builder.Property(x => x.Name)
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(x => x.Type)
                   .IsRequired();

            builder.HasOne(x => x.Organization)
                .WithMany(x=>x.ProcurementProcesses)
                .HasForeignKey(x=>x.OrganizationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.CreatedBy).HasMaxLength(150).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.UpdatedBy).HasMaxLength(150).IsRequired(false);
        }
    }
}
