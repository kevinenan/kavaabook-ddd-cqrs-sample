using System;
using KavaaBook.Domain.Entities.MemberAggregate;
using KavaaBook.Domain.Entities.PostAggregate.Events;
using KavaaBook.Domain.SeedWork;

namespace KavaaBook.Domain.Entities.PostAggregate
{
    public class PostSignal : Entity
    {
        internal MemberId SignalorId { get; private set; }
        internal PostId PostId { get; private set; }
        private string _reason;
        private DateTime _signalDate;

        private PostSignal()
        {
            // required by EF
        }

        internal PostSignal(PostId postId, MemberId memberSignalorId, string reason)
        {
            if (postId == null)
                throw new ArgumentNullException(nameof(postId));
            if (memberSignalorId == null)
                throw new ArgumentNullException(nameof(memberSignalorId));

            PostId = postId;
            SignalorId = memberSignalorId;
            _reason = reason;
            _signalDate = DateTime.Now;

            AddDomainEvent(new PostSignaledDomainEvent(
                PostId,
                SignalorId,
                _reason,
                _signalDate));
        }
    }
}