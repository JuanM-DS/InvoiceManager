using InvoiceManager.Api.Persistence.QueryContext.QueryModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManager.Api.Persistence.Query.Configurations;

public class AddressModelConfiguration : IEntityTypeConfiguration<AddressModel>
{
    public void Configure(EntityTypeBuilder<AddressModel> builder)
    {
        builder.ToTable("Addresses");
        builder.HasKey(x => x.Id);
    }
}
