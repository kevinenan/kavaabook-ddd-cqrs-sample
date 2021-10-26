using KavaaBook.Domain.Entities.PostAggregate;
using KavaaBook.Domain.SeedWork;

namespace KavaaBook.Domain.Entities.PostCommentAggregate.Events
{
    public class PostCommentAddedDomainEvent : DomainEvent
    {
        public PostCommentAddedDomainEvent(PostCommentId postCommentId, PostId postId, string comment)
        {
            PostCommentId = postCommentId;
            PostId = postId;
            Comment = comment;
        }

        public PostCommentId PostCommentId { get; }
        public PostId PostId { get; }
        public string Comment { get; }
    }
}