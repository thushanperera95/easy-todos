namespace EasyTodos.Domain.Common;

public abstract class AuditingEntity : BaseEntity
{
    public string CreatedBy { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string UpdatedBy { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}