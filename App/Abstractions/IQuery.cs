using MediatR;

namespace App.Abstractions;

public interface IQuery<TResponse> : IRequest<TResponse>
{
}