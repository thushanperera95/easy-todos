using Microsoft.EntityFrameworkCore;

namespace backend.Database.Contexts;

public class UserContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public UserContext(DbContextOptions<UserContext> options) : base(options) {}
}