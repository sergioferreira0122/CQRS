using CommandHandler.Domain;
using Microsoft.EntityFrameworkCore;

namespace CommandHandler.Infra
{
    public class ConnectionContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=commandhandler;user=root;password=");
        }
    }
}