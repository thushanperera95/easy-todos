namespace backend.Models;

public class Todo
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    public bool IsComplete { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public User CreateUser { get; set; } = null!;
    public DateTimeOffset UpdatedAt { get; set; }
    public User UpdateUser { get; set; } = null!;
}