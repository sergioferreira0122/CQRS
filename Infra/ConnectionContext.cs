using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class ConnectionContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=commandhandler;user=root;password=");
        }
    }
}