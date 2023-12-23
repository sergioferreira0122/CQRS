using App.Abstractions;

namespace App.UserHandler.Queries.GetByIdUser;

public class GetByIdUserQuery : IQuery<GetByIdUserResponse?>
{
    public int Id { get; set; }
}