using System.Threading;
using System.Threading.Tasks;
using KavaaBook.Domain.Entities.PostAggregate.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KavaaBook.Application.Posts.EventHandlers
{
    internal class PostSignaledEventHandler : INotificationHandler<PostSignaledDomainEvent>
    {
        private readonly ILogger<PostSignaledEventHandler> _logger;

        public PostSignaledEventHandler(ILogger<PostSignaledEventHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(PostSignaledDomainEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle domain event. Event - {event}", notification.GetType().Name);
        }
    }
}