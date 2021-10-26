using System.Collections.Generic;
using System.Linq;
using KavaaBook.Domain.SeedWork;

namespace KavaaBook.Persistence
{
    internal class DomainEventsAccessor : IDomainEventsAccessor
    {
        private readonly BookContext _bookContext;

        public DomainEventsAccessor(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public IReadOnlyCollection<IDomainEvent> GetAllDomainEvents()
        {
            var domainEntities = _bookContext.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            return domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();
        }

        public void ClearAllDomainEvents()
        {
            var domainEntities = _bookContext.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            domainEntities
                .ForEach(entity => entity.Entity.ClearDomainEvents());
        }
    }
}