using EasyTodos.Application.Common.Interfaces;
using EasyTodos.Domain.Common;
using EasyTodos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyTodos.Infrastructure;

public class DatabaseContext : DbContext, IDatabaseContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; } = null!;
    public virtual DbSet<TodoItem> TodoItems { get; set; } = null!;

    public override int SaveChanges()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e is { Entity: AuditingEntity, State: EntityState.Added or EntityState.Modified });

        foreach (var entityEntry in entries)
        {
            ((AuditingEntity)entityEntry.Entity).UpdatedAt = DateTimeOffset.Now;

            if (entityEntry.State == EntityState.Added)
                ((AuditingEntity)entityEntry.Entity).CreatedAt = DateTimeOffset.Now;
        }

        return base.SaveChanges();
    }
}