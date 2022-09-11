using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace backend.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    
    [JsonIgnore]
    public string Hash { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    
    [JsonIgnore]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTimeOffset CreatedAt { get; set; }
}