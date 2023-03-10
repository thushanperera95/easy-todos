using AutoMapper;
using AutoMapper.QueryableExtensions;
using EasyTodos.Application.Common.Interfaces;

namespace EasyTodos.Application.TodoItems.Queries;

public class GetTodoItemsByUsernameQuery
{
    private readonly IDatabaseContext _context;
    private readonly IMapper _mapper;

    public GetTodoItemsByUsernameQuery(IDatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IReadOnlyList<TodoItemDto> Handle(string username)
    {
        return _context.TodoItems.Where(t => t.CreatedBy == username)
            .ProjectTo<TodoItemDto>(_mapper.ConfigurationProvider).ToList();
    }
}