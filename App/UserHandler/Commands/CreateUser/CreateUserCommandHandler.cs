using App.Abstractions;
using Domain.Abstractions;
using Domain.Entities;

namespace App.UserHandler.Commands.CreateUser;

public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
{
    private readonly CreateUserValidator _createUserValidator;
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(CreateUserValidator createUserValidator, IUserRepository userRepository)
    {
        _createUserValidator = createUserValidator;
        _userRepository = userRepository;
    }

    public async Task<Result> HandleAsync(CreateUserCommand createUserCommand)
    {
        var validatorResult = await _createUserValidator.IsValidAsync(createUserCommand);
        if (validatorResult.IsFailure)
            return validatorResult;

        var user = Mapper(createUserCommand);

        await _userRepository.AddUserAsync(user);

        return Result.Success();
    }

    private static User Mapper(CreateUserCommand createUserCommand)
    {
        var user = new User()
        {
            Name = createUserCommand.Name,
            Email = createUserCommand.Email,
            Password = createUserCommand.Password,
            BirthdayDate = createUserCommand.BirthdayDate.ToDateTime(new TimeOnly()),
        };
        return user;
    }
}