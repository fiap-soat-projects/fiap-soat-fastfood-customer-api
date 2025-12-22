using Domain.Entities;
using Infrastructure.Sql.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.Entities;

[ExcludeFromCodeCoverage]
[EntityTypeConfiguration(typeof(CustomerSqlEntityConfiguration))]
internal class CustomerSql : SqlEntity
{
    public string? Name { get; set; }
    public string? Cpf { get; set; }
    public string? Email { get; set; }

    public CustomerSql()
    {

    }

    internal CustomerSql(Customer customer)
    {
        Name = customer.Name;
        Cpf = customer.Cpf;
        Email = customer.Email;
    }

    internal Customer ToDomain()
    {
        return new Customer(Id, CreatedAt)
        {
            Name = Name!,
            Cpf = Cpf!,
            Email = Email!
        };
    }
}
