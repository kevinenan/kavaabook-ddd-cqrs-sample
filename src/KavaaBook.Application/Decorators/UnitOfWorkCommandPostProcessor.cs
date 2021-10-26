using System.Threading;
using System.Threading.Tasks;
using KavaaBook.Application.SeedWork;
using KavaaBook.Domain.SeedWork;
using MediatR.Pipeline;

namespace KavaaBook.Application.Decorators
{
    internal class UnitOfWorkCommandPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
        where TRequest : ICommandBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkCommandPostProcessor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}