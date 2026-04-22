using InvoiceManager.Api.Domain.Entities;
using InvoiceManager.Api.Domain.Enumerables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManager.Api.Persistence.EFContext.Configurations
{
    public class PhoneNumberConfigurations : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.ToTable("PhoneNumber");
            builder.HasKey(x => x.Id)
                   .IsClustered();
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Number).IsRequired();
            builder.Property(x => x.Type)
                   .IsRequired()
                   .HasConversion(x=>x.ToString(), x=> Enum.Parse<PhoneNumberType>(x));

            builder.Property(x => x.SupplierId).IsRequired();

            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.CreatedBy).HasMaxLength(150).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.UpdatedBy).HasMaxLength(150).IsRequired(false);
        }
    }
}
