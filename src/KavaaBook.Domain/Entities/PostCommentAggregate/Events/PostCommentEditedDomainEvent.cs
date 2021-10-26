using KavaaBook.Domain.SeedWork;

namespace KavaaBook.Domain.Entities.PostCommentAggregate.Events
{
    public class PostCommentEditedDomainEvent : DomainEvent
    {
        public PostCommentEditedDomainEvent(PostCommentId postCommentId, string editedText)
        {
            PostCommentId = postCommentId;
            EditedText = editedText;
        }

        public string EditedText { get; }
        public PostCommentId PostCommentId { get; }
    }
}