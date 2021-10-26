using KavaaBook.Domain.Entities.MemberAggregate;
using KavaaBook.Domain.SeedWork;

namespace KavaaBook.Domain.Entities.PostCommentAggregate.Rules
{
    public class PostCommentCanBeEditedOnlyByAuthorRule : IBusinessRule
    {
        private readonly MemberId _authorId;
        private readonly MemberId _editorId;

        public PostCommentCanBeEditedOnlyByAuthorRule(MemberId authorId, MemberId editorId)
        {
            _authorId = authorId;
            _editorId = editorId;
        }

        public string Message => "Only the author of a post comment can edit it.";

        public bool IsBroken() => _editorId != _authorId;
    }
}