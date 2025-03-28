﻿using App.Abstractions;
using Domain.Abstractions;

namespace App.UserHandler.Commands.CreateUser
{
    public class CreateUserValidator : IValidator<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result> IsValidAsync(
            CreateUserCommand createUserCommand,
            CancellationToken cancellationToken)
        {
            var isEmailUsed = _userRepository.ExistsByEmailAsync(createUserCommand.Email, cancellationToken);

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