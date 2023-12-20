using Domain.Abstractions;

namespace App.UserUseCases.CreateUser
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
            var isEmailUsed = _userRepository.ExistsByEmailAsync(createUserCommand.Email);

            if (!createUserCommand.Email.Equals(createUserCommand.EmailConfirmed))
            {
                return UserErrors.EmailNotMatch;
            }

            if (!createUserCommand.Password.Equals(createUserCommand.PasswordConfirmed))
            {
                return UserErrors.PasswordNotMatch;
            }

            if (await isEmailUsed)
            {
                return UserErrors.EmailUsed;
            }

            return Result.Success();
        }
    }
}