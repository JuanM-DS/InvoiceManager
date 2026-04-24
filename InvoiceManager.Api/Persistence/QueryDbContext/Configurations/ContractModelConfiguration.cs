using InvoiceManager.Api.Persistence.QueryModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManager.Api.Persistence.QueryDbContext.Configurations;

public class ContractModelConfiguration : IEntityTypeConfiguration<ContractModel>
{
    public void Configure(EntityTypeBuilder<ContractModel> builder)
    {
        builder.ToTable("Contracts");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Organization)
            .WithMany()
            .HasForeignKey(x => x.OrganizationId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
