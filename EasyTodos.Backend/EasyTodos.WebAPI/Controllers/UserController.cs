using EasyTodos.Application.Users.Commands.CreateUser;
using EasyTodos.Application.Users.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EasyTodos.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly CreateUserCommandHandler _createUserCommandHandler;
    private readonly GetUserByUsernameQuery _getUserByUsernameQuery;
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger, GetUserByUsernameQuery getUserByUsernameQuery,
        CreateUserCommandHandler createUserCommandHandler)
    {
        _logger = logger;
        _getUserByUsernameQuery = getUserByUsernameQuery;
        _createUserCommandHandler = createUserCommandHandler;
    }

    [HttpGet("{username:string}")]
    public IActionResult GetByUsername(string username)
    {
        var user = _getUserByUsernameQuery.Handle(username);
        return Ok(user);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateUserCommand newUser)
    {
        var userId = _createUserCommandHandler.Handle(newUser);
        return CreatedAtAction(nameof(Create), new { id = userId });
    }
}