using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public record NewUser(
    [Required]string Username,
    [Required]string Password,
    [Required]string FirstName,
    [Required]string LastName,
    [Required]string Email
);