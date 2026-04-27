using InvoiceManager.Api.Domain.Entities;
using InvoiceManager.Api.Persistence.QueryContext.QueryModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManager.Api.Persistence.Query.Configurations;

public class ContractModelConfiguration : IEntityTypeConfiguration<ContractModel>
{
    public void Configure(EntityTypeBuilder<ContractModel> builder)
    {
        builder.ToTable("Contracts");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.ProcurementProcessModel)
            .WithMany(x=>x.Contracts)
            .HasForeignKey(x => x.OrganizationId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.SchoolModels)
                .WithMany(x => x.ContractModels)
                .UsingEntity<ContractSchool>();
    }
}
