using System.Diagnostics.CodeAnalysis;

namespace Adapter.Presenters.DTOs;

[ExcludeFromCodeCoverage]
public record CreateCustomerRequest
{
    public required string Name { get; init; }
    public required string Cpf { get; init; }
    public string? Email { get; init; }
}
