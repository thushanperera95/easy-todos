using EasyTodos.Domain.Common;

namespace EasyTodos.Application.TodoItems.Queries;

public class TodoItemDto : AuditingEntity
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset CompletionDate { get; set; }
    public int Ordinal { get; set; }
}