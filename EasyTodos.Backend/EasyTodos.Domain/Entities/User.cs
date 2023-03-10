using EasyTodos.Domain.Common;

namespace EasyTodos.Domain.Entities;

public class User : AuditingEntity
{
    public string Username { get; set; } = null!;
    public string Hash { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
}