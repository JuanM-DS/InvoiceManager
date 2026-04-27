using InvoiceManager.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManager.Api.Persistence.Command.Configurations
{
    public class PhoneNumberConfigurations : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.ToTable("PhoneNumbers");
            builder.HasKey(x => x.Id)
                   .IsClustered();
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.HasIndex(x => x.Number).IsUnique();

            builder.Property(x => x.Number)
                   .IsRequired();
            builder.Property(x => x.Type)
                   .IsRequired();
            builder.Property(x => x.OwnerType)
                   .IsRequired();
            builder.Property(x => x.OwnerId)
                   .IsRequired();

            builder.HasIndex(x => new { x.OwnerType, x.OwnerId });

            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.CreatedBy).HasMaxLength(150).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.UpdatedBy).HasMaxLength(150).IsRequired(false);
        }
    }
}
