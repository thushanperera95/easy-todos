namespace backend.Models;

public class Todo : BaseEntity
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    public DateTimeOffset CompletionDate { get; set; }
    public int Ordinal { get; set; }
    public User CreateUser { get; set; } = null!;
    public User UpdateUser { get; set; } = null!;
}