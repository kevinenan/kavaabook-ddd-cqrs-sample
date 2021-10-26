using System.Collections.Generic;
using KavaaBook.Domain.SeedWork;

namespace KavaaBook.Persistence
{
    public interface IDomainEventsAccessor
    {
        IReadOnlyCollection<IDomainEvent> GetAllDomainEvents();

        void ClearAllDomainEvents();
    }
}