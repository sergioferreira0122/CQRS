using App.Abstractions;
using Domain.Abstractions;
using Domain.Entities;

namespace App.UserHandler.Commands.CreateUser;

public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
{
    private readonly IValidator<CreateUserCommand> _validator;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper<CreateUserCommand, User> _mapper;

    public CreateUserCommandHandler(
        IValidator<CreateUserCommand> createUserValidator,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IMapper<CreateUserCommand, User> mapper)
    {
        _validator = createUserValidator;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result> Handle(
        CreateUserCommand createUserCommand,
        CancellationToken cancellationToken)
    {
        var validatorResult = await _validator.IsValidAsync(createUserCommand, cancellationToken);
        if (validatorResult.IsFailure)
            return validatorResult;

        var user = _mapper.Map(createUserCommand);

        await _userRepository.AddUserAsync(user, cancellationToken);

        await _unitOfWork.Commit();

        return Result.Success();
    }
}