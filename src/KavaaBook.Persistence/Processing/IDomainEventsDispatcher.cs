using System.Threading;
using System.Threading.Tasks;

namespace KavaaBook.Persistence.Processing
{
    public interface IDomainEventsDispatcher
    {
        Task DispatchEventsAsync(CancellationToken cancellationToken = default);
    }
}