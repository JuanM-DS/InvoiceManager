using InvoiceManager.Api.Persistence.QueryModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManager.Api.Persistence.QueryDbContext.Configurations;

public class PhoneNumberModelConfiguration : IEntityTypeConfiguration<PhoneNumberModel>
{
    public void Configure(EntityTypeBuilder<PhoneNumberModel> builder)
    {
        builder.ToTable("PhoneNumbers");
        builder.HasKey(x => x.Id);
    }
}
