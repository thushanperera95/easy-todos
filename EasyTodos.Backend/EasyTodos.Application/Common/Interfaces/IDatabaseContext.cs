using EasyTodos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyTodos.Application.Common.Interfaces;

public interface IDatabaseContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<TodoItem> TodoItems { get; set; }
    public int SaveChanges();
}