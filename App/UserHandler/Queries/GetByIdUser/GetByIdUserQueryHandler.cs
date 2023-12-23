using App.Abstractions;
using Domain.Abstractions;
using Domain.Entities;

namespace App.UserHandler.Queries.GetByIdUser;

public class GetByIdUserQueryHandler : IQueryHandler<GetByIdUserQuery, GetByIdUserResponse?>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper<User, GetByIdUserResponse> _mapper;

    public GetByIdUserQueryHandler(
        IUserRepository userRepository,
        IMapper<User, GetByIdUserResponse> mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdUserResponse?> Handle(
        GetByIdUserQuery query,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(query.Id, cancellationToken);

        return user != null ? _mapper.Map(user) : null;
    }
}