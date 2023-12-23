using App.Abstractions;
using Domain.Entities;

namespace App.UserHandler.Queries.GetByIdUser
{
    public class GetByIdUserMapper : IMapper<User, GetByIdUserResponse>
    {
        public GetByIdUserResponse Map(User data)
        {
            var response = new GetByIdUserResponse
            {
                Id = data.Id,
                Email = data.Email,
                Name = data.Name,
                BirthdayDate = DateOnly.FromDateTime(data.BirthdayDate),
            };

            return response;
        }
    }
}
