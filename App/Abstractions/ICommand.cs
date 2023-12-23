using MediatR;

namespace App.Abstractions
{
    public interface ICommand : IRequest<Result>
    {
    }
}