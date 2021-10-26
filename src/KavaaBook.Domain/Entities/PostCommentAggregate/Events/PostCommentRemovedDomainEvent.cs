using KavaaBook.Domain.SeedWork;

namespace KavaaBook.Domain.Entities.PostCommentAggregate.Events
{
    public class PostCommentRemovedDomainEvent : DomainEvent

    {
        public PostCommentRemovedDomainEvent(PostCommentId postId)
        {
            PostCommentId = postId;
        }

        public PostCommentId PostCommentId { get; }
    }
}