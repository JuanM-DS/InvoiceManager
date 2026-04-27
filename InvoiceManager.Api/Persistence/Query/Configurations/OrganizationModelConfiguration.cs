using InvoiceManager.Api.Persistence.QueryContext.QueryModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManager.Api.Persistence.Query.Configurations;

public class OrganizationModelConfiguration : IEntityTypeConfiguration<OrganizationModel>
{
    public void Configure(EntityTypeBuilder<OrganizationModel> builder)
    {
        builder.ToTable("Organizations");
        builder.HasKey(x => x.Id);
    }
}
