using App.Abstractions;
using App.UserHandler.Commands.CreateUser;
using Domain.Abstractions;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            //ConnectionContext
            services.AddDbContext<ConnectionContext>();
            //ConnectionContext

            //UnitOfWork
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            //UnitOfWork

            //Repositories
            services.AddTransient<IUserRepository, UserRepository>();
            //Repositories

            return services;
        }
    }
}
