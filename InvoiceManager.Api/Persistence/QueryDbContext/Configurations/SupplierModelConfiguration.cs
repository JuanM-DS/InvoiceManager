using InvoiceManager.Api.Persistence.QueryModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManager.Api.Persistence.QueryDbContext.Configurations;

public class SupplierModelConfiguration : IEntityTypeConfiguration<SupplierModel>
{
    public void Configure(EntityTypeBuilder<SupplierModel> builder)
    {
        builder.ToTable("Suppliers");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Address)
            .WithMany()
            .HasForeignKey(x => x.AddressId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.PhoneNumbers)
            .WithMany();
    }
}
