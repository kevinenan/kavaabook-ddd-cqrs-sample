using KavaaBook.Domain.SeedWork;

namespace KavaaBook.Domain.Entities.MemberAggregate.Events
{
    public class MemberEditedDomainEvent : DomainEvent
    {
        public MemberEditedDomainEvent(MemberId memberId)
        {
            MemberId = memberId;
        }

        public MemberId MemberId { get; }
    }
}