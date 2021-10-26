using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KavaaBook.Persistence.Processing
{
    internal class DomainEventsDispatcher : IDomainEventsDispatcher
    {
        private readonly ILogger<DomainEventsDispatcher> _logger;
        private readonly IPublisher _mediator;
        private readonly IDomainEventsAccessor _domainEventsProvider;

        public DomainEventsDispatcher(
            ILogger<DomainEventsDispatcher> logger,
            IPublisher mediator,
            IDomainEventsAccessor domainEventsProvider)
        {
            _logger = logger;
            _mediator = mediator;
            _domainEventsProvider = domainEventsProvider;
        }

        public async Task DispatchEventsAsync(CancellationToken cancellationToken)
        {
            var domainEvents = _domainEventsProvider.GetAllDomainEvents();

            _domainEventsProvider.ClearAllDomainEvents();

            foreach (var domainEvent in domainEvents)
            {
                _logger.LogInformation("Publishing domain event. Event - {event}", domainEvent.GetType().Name);
                await _mediator.Publish(domainEvent, cancellationToken);
            }
        }
    }
}