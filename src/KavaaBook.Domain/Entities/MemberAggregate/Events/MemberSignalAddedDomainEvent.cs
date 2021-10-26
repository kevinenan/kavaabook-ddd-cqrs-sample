using System;
using KavaaBook.Domain.SeedWork;

namespace KavaaBook.Domain.Entities.MemberAggregate.Events
{
    public class MemberSignalAddedDomainEvent : DomainEvent
    {
        public MemberSignalAddedDomainEvent(MemberId memberSignaledId, MemberId memberSignalorId, string reason, DateTime signalDate)
        {
            MemberSignaledId = memberSignaledId;
            MemberSignalorId = memberSignalorId;
            Reason = reason;
            SignalDate = signalDate;
        }

        public MemberId MemberSignalorId { get; }
        public MemberId MemberSignaledId { get; }
        public string Reason { get; }
        public DateTime SignalDate { get; }
    }
}