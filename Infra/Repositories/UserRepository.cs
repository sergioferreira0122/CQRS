using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ConnectionContext _dbContext;

        public UserRepository(ConnectionContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUserAsync(User user, CancellationToken cancellationToken)
        {
            await _dbContext.Users.AddAsync(user, cancellationToken);
        }

        public Task DeleteUserAsync(User user)
        {
            _dbContext.Users.Remove(user);
            return Task.CompletedTask;
        }

        public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Email.Equals(email), cancellationToken) != null;
        }

        public async Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<User>> GetUsersAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Users.ToListAsync(cancellationToken);
        }

        public Task UpdateUserAsync(User user)
        {
            _dbContext.Users.Entry(user).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}