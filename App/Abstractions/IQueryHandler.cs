namespace App.Abstractions
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery
    {
        Task<TResult?> HandleAsync(TQuery query, CancellationToken cancellationToken);
    }
}