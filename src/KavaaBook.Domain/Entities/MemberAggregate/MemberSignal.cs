using System;
using KavaaBook.Domain.Entities.MemberAggregate.Events;
using KavaaBook.Domain.SeedWork;

namespace KavaaBook.Domain.Entities.MemberAggregate
{
    public class MemberSignal : Entity
    {
        internal MemberId SignalorId { get; }
        internal MemberId SignaledId { get; }
        private string _reason;
        private DateTime _signalDate;

        private MemberSignal()
        {
            // required by EF
        }

        internal MemberSignal(MemberId signaledId, MemberId signalorId, string reason)
        {
            if (signaledId == null)
                throw new ArgumentNullException(nameof(signaledId));
            if (signalorId == null)
                throw new ArgumentNullException(nameof(signalorId));

            SignaledId = signaledId;
            SignalorId = signalorId;
            _reason = reason;
            _signalDate = DateTime.Now;

            AddDomainEvent(new MemberSignalAddedDomainEvent(
                SignaledId,
                SignaledId,
                _reason,
                _signalDate));
        }
    }
}