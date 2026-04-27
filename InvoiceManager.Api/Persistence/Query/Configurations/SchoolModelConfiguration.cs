using InvoiceManager.Api.Persistence.QueryContext.QueryModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManager.Api.Persistence.Query.Configurations;

public class SchoolModelConfiguration : IEntityTypeConfiguration<SchoolModel>
{
    public void Configure(EntityTypeBuilder<SchoolModel> builder)
    {
        builder.ToTable("Schools");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Address)
            .WithMany()
            .HasForeignKey(x => x.AddressId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.PhoneNumber)
            .WithMany()
            .HasForeignKey(x => x.PhoneNumberId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
