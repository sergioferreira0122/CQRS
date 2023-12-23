using App.UserHandler.Commands.CreateUser;

namespace App.Abstractions
{
    public interface IValidator<TCommand> where TCommand : ICommand
    {
        Task<Result> IsValidAsync(TCommand tCommand, CancellationToken cancellationToken);
    }
}
