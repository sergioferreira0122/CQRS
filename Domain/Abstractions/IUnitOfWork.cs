namespace Domain.Abstractions
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}