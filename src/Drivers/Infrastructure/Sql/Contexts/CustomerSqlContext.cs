using Infrastructure.Entities;
using Infrastructure.Sql.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.Sql.Contexts;

[ExcludeFromCodeCoverage]
internal class CustomerSqlContext : DbContext
{
    public DbSet<CustomerSql> Customers => Set<CustomerSql>();

    public CustomerSqlContext(DbContextOptions<CustomerSqlContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerSqlEntityConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
