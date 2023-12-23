using System.ComponentModel.DataAnnotations;
using App.Abstractions;
using MediatR;

namespace App.UserHandler.Commands.CreateUser
{
    public class CreateUserCommand : ICommand
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        public DateOnly BirthdayDate { get; set; }

        [Required]
        public required string EmailConfirmed { get; set; }

        [Required]
        public required string PasswordConfirmed { get; set; }
    }
}