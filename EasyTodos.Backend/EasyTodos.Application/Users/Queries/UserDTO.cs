using EasyTodos.Domain.Common;

namespace EasyTodos.Application.Users.Queries;

public class UserDto : AuditingEntity
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
}