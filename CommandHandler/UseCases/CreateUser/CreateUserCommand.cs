﻿using CommandHandler.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CommandHandler.UseCases.CreateUser
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