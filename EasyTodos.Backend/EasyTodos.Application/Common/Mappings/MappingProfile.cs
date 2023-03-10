using AutoMapper;
using EasyTodos.Application.TodoItems.Queries;
using EasyTodos.Application.Users.Queries;
using EasyTodos.Domain.Entities;

namespace EasyTodos.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TodoItem, TodoItemDto>();
        CreateMap<UserDto, UserDto>();
    }
}