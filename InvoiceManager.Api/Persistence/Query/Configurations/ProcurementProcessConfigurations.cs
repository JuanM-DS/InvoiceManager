using InvoiceManager.Api.Persistence.QueryContext.QueryModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManager.Api.Persistence.Query.Configurations
{
    public class ProcurementProcessConfigurationsModel : IEntityTypeConfiguration<ProcurementProcessModel>
    {
        public void Configure(EntityTypeBuilder<ProcurementProcessModel> builder)
        {
            builder.ToTable("ProcurementProcesses");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Organization)
                .WithMany(x=>x.ProcurementProcessModels)
                .HasForeignKey(x=>x.OrganizationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
