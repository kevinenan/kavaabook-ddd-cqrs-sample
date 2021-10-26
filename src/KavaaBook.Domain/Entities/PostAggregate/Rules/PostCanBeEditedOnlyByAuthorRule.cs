using KavaaBook.Domain.SeedWork;
using KavaaBook.Domain.Entities.MemberAggregate;

namespace KavaaBook.Domain.Entities.PostAggregate.Rules
{
    public class PostCanBeEditedOnlyByAuthorRule : IBusinessRule
    {
        private readonly MemberId _authorId;
        private readonly MemberId _editorId;
        public string Message => "Only the author of a post can edit it.";

        public bool IsBroken() => _editorId != _authorId;

        public PostCanBeEditedOnlyByAuthorRule(MemberId authorId, MemberId editorId)
        {
            _authorId = authorId;
            _editorId = editorId;
        }
    }
}