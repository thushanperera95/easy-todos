using AutoMapper;
using AutoMapper.QueryableExtensions;
using EasyTodos.Application.Common.Interfaces;

namespace EasyTodos.Application.Users.Queries;

public class GetUserByUsernameQuery
{
    private readonly IDatabaseContext _context;
    private readonly IMapper _mapper;

    public GetUserByUsernameQuery(IDatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IReadOnlyList<UserDto> Handle(string username)
    {
        return _context.Users.Where(u => u.Username == username)
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider).ToList();
    }
}