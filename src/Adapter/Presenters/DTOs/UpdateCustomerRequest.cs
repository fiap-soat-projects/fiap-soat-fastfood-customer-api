using System.Diagnostics.CodeAnalysis;

namespace Adapter.Presenters.DTOs;


[ExcludeFromCodeCoverage]
public record UpdateCustomerRequest
{
    public int? Id { get; init; }
    public required string Name { get; init; }
    public string? Email { get; init; }
}
