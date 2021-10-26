using System;
using KavaaBook.Domain.Entities.MemberAggregate;
using KavaaBook.Domain.SeedWork;

namespace KavaaBook.Domain.Entities.PostAggregate.Events
{
    public class PostSignaledDomainEvent : DomainEvent
    {
        public PostSignaledDomainEvent(PostId postId, MemberId memberId, string reason, DateTime signalDate)
        {
            PostId = postId;
            MemberId = memberId;
            Reason = reason;
            SignalDate = signalDate;
        }

        public MemberId MemberId { get; }
        public PostId PostId { get; }
        public string Reason { get; }
        public DateTime SignalDate { get; }
    }
}