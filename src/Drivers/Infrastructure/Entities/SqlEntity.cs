using Infrastructure.Entities.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.Entities;

[ExcludeFromCodeCoverage]
internal abstract class SqlEntity : ISqlEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    protected SqlEntity()
    {
        CreatedAt = DateTime.UtcNow;
    }
}
