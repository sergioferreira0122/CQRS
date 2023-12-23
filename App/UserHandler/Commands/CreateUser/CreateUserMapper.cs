
using App.Abstractions;
using Domain.Entities;

namespace App.UserHandler.Commands.CreateUser
{
    public class CreateUserMapper : IMapper<CreateUserCommand, User>
    {
        public User Map(CreateUserCommand data)
        {
            var user = new User()
            {
                Name = data.Name,
                Email = data.Email,
                Password = data.Password,
                BirthdayDate = data.BirthdayDate.ToDateTime(new TimeOnly()),
            };
            return user;
        }
    }
}
