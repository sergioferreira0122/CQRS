using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra
{
    public class ConnectionContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public required DbSet<User> Users { get; set; }

        public ConnectionContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_configuration.GetConnectionString("DatabaseConnection")!);
        }
    }
}