using System.Threading;
using System.Threading.Tasks;

namespace KavaaBook.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(
            CancellationToken cancellationToken = default);
    }
}