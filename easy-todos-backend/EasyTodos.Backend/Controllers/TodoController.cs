using backend.Database;
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
    public IActionResult GetAll()
    {
        var todos = _db.Todos.ToList();
        return Ok(todos);
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        var todo = _db.Todos.FirstOrDefault(u => u.Id == id);
        if (todo == null)
        {
            return NotFound();
        }
        
        return Ok(todo);
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
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
    public IActionResult Create([FromBody]NewTodo newTodo)
    {
        var todo = EntityMapper.Map(newTodo);
        _db.Todos.Add(todo);
        _db.SaveChanges();

        return CreatedAtAction(nameof(Create), new { id = todo.Id }, todo);
    }
}