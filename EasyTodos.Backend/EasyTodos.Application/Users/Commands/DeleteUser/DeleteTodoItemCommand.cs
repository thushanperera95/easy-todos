using EasyTodos.Application.Common.Interfaces;

namespace EasyTodos.Application.Users.Commands.DeleteUser;

public class DeleteTodoItemCommandHandler
{
    private readonly IDatabaseContext _context;

    public DeleteTodoItemCommandHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public void Handle(int id)
    {
        var entity = _context.TodoItems.SingleOrDefault(t => t.Id == id);
        _context.TodoItems.Remove(entity ?? throw new InvalidOperationException(nameof(entity)));
        _context.SaveChanges();
    }
}