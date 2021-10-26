using System;
using KavaaBook.Domain.Entities.MemberAggregate;
using KavaaBook.Domain.SeedWork;

namespace KavaaBook.Domain.Entities.PostAggregate.Events
{
    public class PostReactAddedDomainEvent : DomainEvent
    {
        public PostReactAddedDomainEvent(PostId postId, MemberId memberId, ReactType reactType, DateTime reactionDate)
        {
            PostId = postId;
            MemberId = memberId;
            ReactType = reactType;
            ReactionDate = reactionDate;
        }

        public MemberId MemberId { get; }
        public PostId PostId { get; }
        public ReactType ReactType { get; }
        public DateTime ReactionDate { get; }
    }
}