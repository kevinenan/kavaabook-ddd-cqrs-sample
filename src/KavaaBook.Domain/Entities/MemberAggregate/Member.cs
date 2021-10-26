using System;
using System.Collections.Generic;
using KavaaBook.Domain.Entities.MemberAggregate.Events;
using KavaaBook.Domain.SeedWork;

namespace KavaaBook.Domain.Entities.MemberAggregate
{
    public class Member : Entity<MemberId>, IAggregateRoot
    {
        private string _userName;
        private string _email;
        private string _firstname;
        private string _lastName;
        private bool _isActived;
        private string _disActivedByReason;
        private DateTime _createdDate;
        private List<MemberSignal> _memberSignals;

        private Member()
        {
            // Only for EF.
            _memberSignals = new List<MemberSignal>();
        }

        public Member(Guid id, string userName,string email, string firstName, string lastName)
        {
            Id = new MemberId(id);
            _userName = userName;
            _email = email;
            _firstname = firstName;
            _lastName = lastName;
            _isActived = true;
            _createdDate = DateTime.Now;
        }

        public void EditProfile(MemberId editorId, string firstName, string lastName)
        {
            //CheckRule(new MemberCanBeEditedOnlyByMemberRule(AuthorId, editorId));

            _firstname = firstName;
            _lastName = lastName;

            AddDomainEvent(new MemberEditedDomainEvent(Id));
        }

        public void Signal(MemberId memberId, string reason)
        {
            _memberSignals.Add(new MemberSignal(Id, memberId, reason));
        }

        public bool IsSignaled() => _memberSignals.Count > 0;
    }
}