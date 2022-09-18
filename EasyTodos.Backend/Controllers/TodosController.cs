using backend.Database.Contexts;
using backend.Models;
using backend.Util;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class TodosController : ControllerBase
{
    private readonly ILogger<TodosController> _logger;
    private readonly DatabaseContext _db;

    public TodosController(ILogger<TodosController> logger, DatabaseContext db)
    {
        _logger = logger;
        _db = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var todos = _db.Todos.ToList();
        return Ok(todos);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var todo = _db.Todos.FirstOrDefault(u => u.Id == id);
        if (todo == null)
        {
            return NotFound();
        }
        
        return Ok(todo);
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteById(int id)
    {
        var todo = _db.Todos.FirstOrDefault(u => u.Id == id);
        if (todo == null)
        {
            return NotFound();
        }

        _db.Todos.Remove(todo);
        _db.SaveChanges();
        return Ok();
    }

    [HttpPost]
    public IActionResult CreateTodo([FromBody]NewTodo newTodo)
    {
        var todo = EntityMapper.Map(newTodo);
        _db.Todos.Add(todo);
        _db.SaveChanges();

        return CreatedAtAction(nameof(CreateTodo), new { id = todo.Id }, todo);
    }
}