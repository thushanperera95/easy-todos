using backend.Database;
using backend.Models;
using backend.Util;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly DatabaseContext _db;

    public UsersController(ILogger<UsersController> logger, DatabaseContext db)
    {
        _logger = logger;
        _db = db;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _db.Users.ToList();
        return Ok(users);
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        var user = _db.Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        
        return Ok(user);
    }

    [HttpPost]
    public IActionResult Create([FromBody]NewUser newUser)
    {
        var user = EntityMapper.Map(newUser);
        _db.Users.Add(user);
        _db.SaveChanges();

        return CreatedAtAction(nameof(Create), new { id = user.Id }, user);
    }
}