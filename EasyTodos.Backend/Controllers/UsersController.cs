using backend.Database.Contexts;
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
    public IActionResult Get()
    {
        var users = _db.Users.ToList();
        return Ok(users);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var user = _db.Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        
        return Ok(user);
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody]NewUser newUser)
    {
        var user = EntityMapper.Map(newUser);
        _db.Users.Add(user);
        _db.SaveChanges();

        return CreatedAtAction(nameof(CreateUser), new { id = user.Id }, user);
    }
}