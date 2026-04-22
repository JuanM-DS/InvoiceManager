using InvoiceManager.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManager.Api.Persistence.EFContext
{
    public class MainContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
