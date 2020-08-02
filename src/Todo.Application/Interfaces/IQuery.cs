using MediatR;

namespace TodoApp.Application.Interfaces
{
    public interface IQuery<TResult> : IRequest<TResult>
    {
    }
}
