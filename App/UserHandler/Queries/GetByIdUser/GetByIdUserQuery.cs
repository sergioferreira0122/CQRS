using App.Abstractions;

namespace App.UserHandler.Queries.GetByIdUser;

public class GetByIdUserQuery : IQuery
{
    public int Id { get; set; }
}