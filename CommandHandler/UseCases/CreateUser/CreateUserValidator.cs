using CommandHandler.Domain;
using CommandHandler.Infra.UserRepository;

namespace CommandHandler.UseCases.CreateUser
{
    public class CreateUserValidator
    {
        private readonly IUserRepository _userRepository;

        public CreateUserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result> IsValidAsync(CreateUserCommand createUserCommand)
        {
            if (!createUserCommand.Email.Equals(createUserCommand.EmailConfirmed))
            {
                return UserErrors.EmailNotMatch;
            }

            if (!createUserCommand.Password.Equals(createUserCommand.PasswordConfirmed))
            {
                return UserErrors.PasswordNotMatch;
            }

            if (await _userRepository.ExistsByEmailAsync(createUserCommand.Email))
            {
                return UserErrors.EmailUsed;
            }

            return Result.Success();
        }
    }
}
