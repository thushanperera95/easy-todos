using backend.Database.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly UserContext _db;

    public UserController(ILogger<UserController> logger, UserContext db)
    {
        _logger = logger;
        _db = db;
    }

    [HttpGet(Name = "GetUser")]
    public IEnumerable<User> Get()
    {
        var users = _db.Users.ToList();
        return users;
    }
}