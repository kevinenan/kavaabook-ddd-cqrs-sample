using System;
using KavaaBook.Domain.Entities.MemberAggregate;
using KavaaBook.Domain.Entities.PostAggregate.Events;
using KavaaBook.Domain.SeedWork;

namespace KavaaBook.Domain.Entities.PostAggregate
{
    public class PostReact : Entity
    {
        //public PostReactId Id { get; private set; }
        internal MemberId ReactorId { get; }

        internal PostId PostId { get; private set; }
        private ReactType _reactType;
        private DateTime _reactionDate;

        private PostReact()
        {
            // required by EF
        }

        internal PostReact(PostId postId, MemberId memberId, ReactType reactType)
        {
            if (postId == null)
                throw new ArgumentNullException(nameof(postId));
            if (memberId == null)
                throw new ArgumentNullException(nameof(memberId));

            //Id = new PostReactId(Guid.NewGuid());
            PostId = postId;
            ReactorId = memberId;
            _reactType = reactType;
            _reactionDate = DateTime.Now;

            AddDomainEvent(new PostReactAddedDomainEvent(
                PostId,
                ReactorId,
                reactType,
                _reactionDate));
        }
    }
}