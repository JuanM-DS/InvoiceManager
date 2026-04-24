using InvoiceManager.Api.Domain.Entities;
using InvoiceManager.Api.Persistence.QueryModels;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManager.Api.Persistence.QueryDbContext
{
    public class QueryDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<AddressModel> Addresses { get; set; }
        public DbSet<InvoiceModel> Invoices { get; set; }
        public DbSet<PhoneNumberModel> PhoneNumbers { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<SchoolModel> Schools { get; set; }
        public DbSet<SupplierModel> Suppliers { get; set; }
        public DbSet<OrganizationModel> Organizations { get; set; }
        public DbSet<Contract> Contracts { get; set; }
            
        protected override void OnModelCreating(ModelBuilder Builder)
        {
            Builder.ApplyConfigurationsFromAssembly(typeof(QueryDbContext).Assembly);
            base.OnModelCreating(Builder);
        }
    }
}
