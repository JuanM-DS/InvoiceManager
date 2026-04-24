using InvoiceManager.Api.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace InvoiceManager.Api.Persistence.Interceptors
{
    public class SaveAuditableInterceptor : SaveChangesInterceptor
    {
        public async override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            if (eventData.Context is null)
                return await base.SavingChangesAsync(eventData, result, cancellationToken);

            UpdateEntities(eventData.Context);

            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void UpdateEntities(DbContext dbContext)
        {
            foreach (var item in dbContext.ChangeTracker.Entries<IAuditable>())
            {
                switch (item.State)
                {
                    case EntityState.Modified:
                        item.Entity.UpdatedBy = "System";
                        item.Entity.UpdatedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        item.Entity.CreatedBy = "System";       
                        item.Entity.CreatedAt = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
