using App.Abstractions;
using App.UserHandler.Commands.CreateUser;
using App.UserHandler.Queries.GetByIdUser;
using Domain.Abstractions;
using Infra;
using Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ConnectionContext>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IValidator<CreateUserCommand>, CreateUserValidator>();
builder.Services.AddTransient<ICommandHandler<CreateUserCommand>, CreateUserCommandHandler>();
builder.Services.AddTransient<IQueryHandler<GetByIdUserQuery, GetByIdUserResponse?>, GetByIdUserQueryHandler >();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();