using App.Abstractions;
using Domain.Abstractions;
using Domain.Entities;

namespace App.UserHandler.Queries.GetByIdUser;

public class GetByIdUserQueryHandler : IQueryHandler<GetByIdUserQuery, GetByIdUserResponse?>
{
    private readonly IUserRepository _userRepository;

    public GetByIdUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetByIdUserResponse?> HandleAsync(GetByIdUserQuery query, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(query.Id, cancellationToken);

        return user != null ? Mapper(user) : null;
    }

    private static GetByIdUserResponse Mapper(User user)
    {
        var response = new GetByIdUserResponse
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name,
            BirthdayDate = DateOnly.FromDateTime(user.BirthdayDate),
        };

        return response;
    }
}