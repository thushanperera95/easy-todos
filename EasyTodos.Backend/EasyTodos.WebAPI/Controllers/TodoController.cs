using EasyTodos.Application.TodoItems.Commands.CreateTodoItem;
using EasyTodos.Application.TodoItems.Commands.DeleteTodoItem;
using EasyTodos.Application.TodoItems.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EasyTodos.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TodosController : ControllerBase
{
    private readonly CreateTodoItemCommandHandler _createTodoItemCommandHandler;
    private readonly DeleteTodoItemCommandHandler _deleteTodoItemCommandHandler;
    private readonly GetTodoItemsByUsernameQuery _getTodoItemsByUsernameQuery;
    private readonly ILogger<TodosController> _logger;

    public TodosController(ILogger<TodosController> logger, CreateTodoItemCommandHandler createTodoItemCommandHandler,
        DeleteTodoItemCommandHandler deleteTodoItemCommandHandler,
        GetTodoItemsByUsernameQuery getTodoItemsByUsernameQuery)
    {
        _logger = logger;
        _createTodoItemCommandHandler = createTodoItemCommandHandler;
        _deleteTodoItemCommandHandler = deleteTodoItemCommandHandler;
        _getTodoItemsByUsernameQuery = getTodoItemsByUsernameQuery;
    }

    [HttpGet("{username:string}")]
    public IActionResult GetByUsername(string username)
    {
        var todos = _getTodoItemsByUsernameQuery.Handle(username);
        return Ok(todos);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        _deleteTodoItemCommandHandler.Handle(id);
        return Ok();
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateTodoItemCommand newTodo)
    {
        var todoId = _createTodoItemCommandHandler.Handle(newTodo);
        return CreatedAtAction(nameof(Create), new { id = todoId });
    }
}