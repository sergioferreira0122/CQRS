using Domain.Entities;

namespace Domain.Abstractions
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync(CancellationToken cancellationToken);

        Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken);

        Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken);

        Task AddUserAsync(User user, CancellationToken cancellationToken);

        void DeleteUser(User user, CancellationToken cancellationToken);

        Task UpdateUserAsync(User user, CancellationToken cancellationToken);
    }
}