using Domain.Entities;
using Infrastructure.Sql.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.Entities;

[ExcludeFromCodeCoverage]
[EntityTypeConfiguration(typeof(CustomerSqlEntityConfiguration))]
internal class CustomerSql : SqlEntity
{
    public required string Name { get; set; }
    public required string Cpf { get; set; }
    public string? Email { get; set; }

    public CustomerSql()
    {

    }

    [SetsRequiredMembers]
    internal CustomerSql(Customer customer)
    {
        Id = customer.Id;
        CreatedAt = customer.CreatedAt;
        Name = customer.Name;
        Cpf = customer.Cpf;
        Email = customer.Email?.ToString();
    }

    internal Customer ToDomain()
    {
        return new Customer(Id, CreatedAt, Name, Cpf, Email, UpdatedAt);
    }
}
