using InvoiceManager.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManager.Api.Persistence.CommandDbContext.Configurations
{
    public class SchoolConfigurations : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.ToTable("SchoolModel");
            builder.HasKey(x => x.Id)
                   .IsClustered();
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.HasIndex(x => x.Code)
                .IsUnique();
            
            builder.HasIndex(x => x.AddressId)
                .IsUnique();

            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
            builder.Property(x => x.HeadMasterName).HasMaxLength(150).IsRequired();
            builder.Property(x => x.RationsNumber).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Order).IsRequired();
            builder.Property(x => x.AddressId).IsRequired();
            builder.Property(x => x.PhoneNumberId).IsRequired();

            builder.HasOne(x => x.PhoneNumber)
                .WithMany()
                .HasForeignKey(x => x.PhoneNumberId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Address)
                    .WithMany()
                    .HasForeignKey(x => x.AddressId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.CreatedBy).HasMaxLength(150).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.UpdatedBy).HasMaxLength(150).IsRequired(false);
        }
    }
}
