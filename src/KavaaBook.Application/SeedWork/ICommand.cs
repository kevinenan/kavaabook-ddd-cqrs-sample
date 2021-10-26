using MediatR;

namespace KavaaBook.Application.SeedWork
{
    public interface ICommand<out TResult> : IRequest<TResult>, ICommandBase
    {
    }

    public interface ICommand : IRequest, ICommandBase
    {
    }

    public interface ICommandBase { }
}