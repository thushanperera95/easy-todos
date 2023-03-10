using System.ComponentModel.DataAnnotations;
using EasyTodos.Application.Common.Interfaces;
using EasyTodos.Domain.Entities;

namespace EasyTodos.Application.Users.Commands.CreateUser;

public record CreateUserCommand(
    [Required] string Username,
    [Required] string Password,
    [Required] string FirstName,
    [Required] string LastName,
    [Required] string Email
);

public class CreateUserCommandHandler
{
    private readonly IDatabaseContext _context;

    public CreateUserCommandHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public int Handle(CreateUserCommand request)
    {
        var entity = new User
        {
            Username = request.Username,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Hash = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        _context.Users.Add(entity);

        _context.SaveChanges();

        return entity.Id;
    }
}