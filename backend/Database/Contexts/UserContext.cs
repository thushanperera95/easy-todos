using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Database.Contexts;

public class UserContext : DbContext
{
    public virtual DbSet<User> Users { get; set; }

    public UserContext()
    {
    }

    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<User>()
            .Property(e => e.CreatedAt)
            .HasDefaultValue(DateTimeOffset.Now);
    }
}