
using System.ComponentModel.DataAnnotations;
using App.Abstractions;

namespace App.UserUseCases.CreateUser
{
    public class CreateUserCommand : ICommand
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateOnly BirthdayDate { get; set; }

        [Required]
        public string EmailConfirmed { get; set; }

        [Required]
        public string PasswordConfirmed { get; set; }
    }
}