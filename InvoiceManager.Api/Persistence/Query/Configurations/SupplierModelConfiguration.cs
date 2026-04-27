using InvoiceManager.Api.Persistence.QueryContext.QueryModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManager.Api.Persistence.Query.Configurations                                                                                                       .Configurations;

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
            .WithOne()
            .HasForeignKey(x=>x.OwnerId);
    }
}
