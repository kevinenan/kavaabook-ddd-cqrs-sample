using System.Threading;
using System.Threading.Tasks;
using KavaaBook.Domain.SeedWork;
using KavaaBook.Persistence.Processing;

namespace KavaaBook.Persistence.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookContext _context;
        private readonly IDomainEventsDispatcher _domainEventsDispatcher;

        public UnitOfWork(
            BookContext context,
            IDomainEventsDispatcher domainEventsDispatcher)
        {
            _context = context;
            _domainEventsDispatcher = domainEventsDispatcher;
        }

        public async Task<int> CommitAsync(
            CancellationToken cancellationToken = default)
        {
            await _domainEventsDispatcher.DispatchEventsAsync();

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}