using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public record NewTodo(
    [Required] string Description,
    [Required] bool IsComplete
);