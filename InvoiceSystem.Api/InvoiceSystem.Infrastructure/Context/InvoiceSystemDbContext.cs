using InvoiceSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Infrastructure.Context;

public class InvoiceSystemDbContext : DbContext
{
    public InvoiceSystemDbContext()
    {
    }

    public InvoiceSystemDbContext(DbContextOptions<InvoiceSystemDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Invoice> Invoices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasOne(x => x.Customer)
                .WithMany(x => x.Invoices)
                .HasForeignKey(x => x.CustomerId);
        });

        SeedData(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1, Firstname = "Beqa", Lastname = "Tchelidze" },
            new Customer { Id = 2, Firstname = "Giorgi", Lastname = "Tchelidze" },
            new Customer { Id = 3, Firstname = "Joseph", Lastname = "Stalin" },
            new Customer { Id = 4, Firstname = "Adolf", Lastname = "Hitler" });
    }
}