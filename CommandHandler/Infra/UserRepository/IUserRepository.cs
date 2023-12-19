using CommandHandler.Domain;

namespace CommandHandler.Infra.UserRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();

        Task<User?> GetByIdAsync(int id);

        Task<bool> ExistsByEmailAsync(string email);

        Task AddUserAsync(User user);

        void DeleteUserAsync(User user);

        Task UpdateUserAsync(User user);
    }
}