using Newtonsoft.Json;

namespace backend.Models;

public class User : BaseEntity
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    
    [JsonIgnore]
    public string Hash { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
}