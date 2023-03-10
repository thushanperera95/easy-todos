using System.ComponentModel.DataAnnotations;
using EasyTodos.Application.Common.Interfaces;
using EasyTodos.Domain.Entities;

namespace EasyTodos.Application.TodoItems.Commands.CreateTodoItem;

public record CreateTodoItemCommand(
    [Required] string Description,
    [Required] string Username
);

public class CreateTodoItemCommandHandler
{
    private readonly IDatabaseContext _context;

    public CreateTodoItemCommandHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public int Handle(CreateTodoItemCommand request)
    {
        var entity = new TodoItem
        {
            Description = request.Description,
            CreatedBy = request.Username,
            UpdatedBy = request.Username
        };

        _context.TodoItems.Add(entity);

        _context.SaveChanges();

        return entity.Id;
    }
}