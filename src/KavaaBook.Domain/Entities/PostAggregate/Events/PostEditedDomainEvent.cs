using KavaaBook.Domain.SeedWork;

namespace KavaaBook.Domain.Entities.PostAggregate.Events
{
    public class PostEditedDomainEvent : DomainEvent
    {
        public PostEditedDomainEvent(PostId postId, string editedText)
        {
            PostId = postId;
            EditedText = editedText;
        }

        public string EditedText { get; }
        public PostId PostId { get; }
    }
}