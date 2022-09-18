using backend.Models;

namespace backend.Util;

public static class EntityMapper
{
    public static User Map(NewUser newUser)
    {
        return new User
        {
            Username   = newUser.Username,
            Email   = newUser.Email,
            FirstName   = newUser.FirstName,
            LastName   = newUser.LastName,
            Hash = BCrypt.Net.BCrypt.HashPassword(newUser.Password)
        };
    } 
    
    public static Todo Map(NewTodo newTodo)
    {
        return new Todo
        {
            Description   = newTodo.Description,
            CreateUser   = newTodo.CreateUser
        };
    } 
}