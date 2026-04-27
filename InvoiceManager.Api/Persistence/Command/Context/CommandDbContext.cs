using InvoiceManager.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManager.Api.Persistence.Command.Context
{
    public class CommandDbContext(DbContextOptions<CommandDbContext> options) : DbContext(options)
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractSchool> contractSchools { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(CommandDbContext).Assembly,
                IsValidEntityTypeConfiguration);
        }

        public bool IsValidEntityTypeConfiguration(Type type)
            => type.FullName?.Contains("Command.Configurations") ?? false;
    }
}
