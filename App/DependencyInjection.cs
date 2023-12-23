using App.Abstractions;
using App.UserHandler.Commands.CreateUser;
using App.UserHandler.Queries.GetByIdUser;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace App
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApp(this IServiceCollection services)
        {
            //Validators
            services.AddTransient<IValidator<CreateUserCommand>, CreateUserValidator>();
            //Validators

            //Mappers
            //Commands
            services.AddTransient<IMapper<CreateUserCommand, User>, CreateUserMapper>();
            //Commands

            //Queries
            services.AddTransient<IMapper<User, GetByIdUserResponse>, GetByIdUserMapper >();
            //Queries
            //Mappers

            return services;
        }
    }
}
