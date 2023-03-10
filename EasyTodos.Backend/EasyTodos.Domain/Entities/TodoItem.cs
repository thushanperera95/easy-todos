using EasyTodos.Domain.Common;

namespace EasyTodos.Domain.Entities;

public class TodoItem : AuditingEntity
{
    public string Description { get; set; } = null!;
    public DateTimeOffset? CompletionDate { get; set; }
    public int? Ordinal { get; set; }
}