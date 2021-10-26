using MediatR;

namespace KavaaBook.Application.SeedWork
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}