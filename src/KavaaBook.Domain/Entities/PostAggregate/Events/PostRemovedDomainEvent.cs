using System;
using KavaaBook.Domain.SeedWork;
using KavaaBook.Domain.Entities.MemberAggregate;

namespace KavaaBook.Domain.Entities.PostAggregate.Events
{

    public class PostRemovedDomainEvent : DomainEvent
    {
        public PostRemovedDomainEvent(PostId postId)
        {
            PostId = postId;
        }

        public PostId PostId { get; }
    }
}