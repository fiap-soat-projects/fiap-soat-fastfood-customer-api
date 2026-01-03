using Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Adapter.Presenters.DTOs;

[ExcludeFromCodeCoverage]
public record class CustomerResponse
{
    public int Id { get; private init; }
    public DateTime CreatedAt { get; private init; }
    public DateTime? UpdatedAt { get; private init; }
    public string Name { get; private init; }
    public string Cpf { get; private init; }
    public string? Email { get; private init; }

    public CustomerResponse(Customer customer)
    {
        Id = customer.Id;
        CreatedAt = customer.CreatedAt;
        UpdatedAt = customer.UpdatedAt;
        Name = customer.Name;
        Cpf = customer.Cpf;
        Email = customer.Email?.ToString();
    }
}
