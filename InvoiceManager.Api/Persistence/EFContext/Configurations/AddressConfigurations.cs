using InvoiceManager.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManager.Api.Persistence.EFContext.Configurations
{
    public class AddressConfigurations : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.HauseNumber).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Street).HasMaxLength(150).IsRequired();
            builder.Property(x => x.SubSector).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Sector).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Municipaly).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Province).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Country).HasMaxLength(150).IsRequired();

            // Auditable
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.CreatedBy).HasMaxLength(150).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.UpdatedBy).HasMaxLength(150).IsRequired(false);
        }
    }
}
