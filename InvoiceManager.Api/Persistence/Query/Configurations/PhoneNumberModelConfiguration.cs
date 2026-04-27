using InvoiceManager.Api.Persistence.QueryContext.QueryModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManager.Api.Persistence.Query.Configurations;

public class PhoneNumberModelConfiguration : IEntityTypeConfiguration<PhoneNumberModel>
{
    public void Configure(EntityTypeBuilder<PhoneNumberModel> builder)
    {
        builder.ToTable("PhoneNumbers");
        builder.HasKey(x => x.Id);
    }
}
