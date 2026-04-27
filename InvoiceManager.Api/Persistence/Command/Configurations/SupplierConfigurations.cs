using InvoiceManager.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManager.Api.Persistence.Command.Configurations
{
    public class SupplierConfigurations : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");

            builder.HasKey(x => x.Id)
                   .IsClustered();

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.HasIndex(x => x.TaxNumber)
                   .IsUnique();

            builder.HasIndex(x => x.Email)
                   .IsUnique();

            builder.HasIndex(x => x.AddressId)
                   .IsUnique();

            builder.Property(x => x.Name)
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(x => x.Email)
                    .HasMaxLength(150)
                   .IsRequired();

            builder.Property(x => x.TaxNumber)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(x => x.AddressId)
                   .IsRequired();

            builder.HasOne(x => x.Address)
                   .WithMany()
                   .HasForeignKey(x => x.AddressId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.PhoneNumbers)
                   .WithOne()
                   .HasForeignKey(x=>x.OwnerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Contracts)
                   .WithOne(x => x.Supplier)
                   .HasForeignKey(x => x.SupplierId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.CreatedBy).HasMaxLength(150).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.UpdatedBy).HasMaxLength(150).IsRequired(false);
        }
    }
}
