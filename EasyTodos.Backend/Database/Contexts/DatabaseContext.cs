using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Database.Contexts;

public class DatabaseContext : DbContext
{
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Todo> Todos { get; set; }

    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<User>()
                .Property(e => e.CreatedAt)
                    .HasDefaultValue(DateTimeOffset.Now);
        
        modelBuilder
            .Entity<Todo>()
                .Property(e => e.CreatedAt)
                    .HasDefaultValue(DateTimeOffset.Now);
    }
}