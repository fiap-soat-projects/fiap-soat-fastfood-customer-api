namespace Infrastructure.Entities.Interfaces;

public interface ISqlEntity
{
    public int Id { get; }
    public DateTime CreatedAt { get; }
    public DateTime? UpdatedAt { get; set; }
}
