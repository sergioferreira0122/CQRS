namespace CommandHandler.Domain.Interfaces
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task<Result> HandleAsync (TCommand command);
    }
}
