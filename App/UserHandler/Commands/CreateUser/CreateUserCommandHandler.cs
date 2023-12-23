using App.Abstractions;
using Domain.Abstractions;
using Domain.Entities;

namespace App.UserHandler.Commands.CreateUser;

public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
{
    private readonly IValidator<CreateUserCommand> _validator;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(IValidator<CreateUserCommand> createUserValidator, IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _validator = createUserValidator;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> HandleAsync(CreateUserCommand createUserCommand, CancellationToken cancellationToken)
    {
        var validatorResult = await _validator.IsValidAsync(createUserCommand, cancellationToken);
        if (validatorResult.IsFailure)
            return validatorResult;

        var user = Mapper(createUserCommand);

        await _userRepository.AddUserAsync(user, cancellationToken);

        await _unitOfWork.Commit();

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