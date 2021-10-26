using KavaaBook.Domain.Entities.MemberAggregate;
using KavaaBook.Domain.SeedWork;

namespace KavaaBook.Domain.Entities.PostCommentAggregate.Rules
{
    public class PostCommentCanBeRemovedOnlyByAuthorOrAdministratorRule : IBusinessRule
    {
        private readonly MemberId _authorId;
        private readonly MemberId _removingMemberId;

        public PostCommentCanBeRemovedOnlyByAuthorOrAdministratorRule(MemberId authorId, MemberId removingMemberId)
        {
            _authorId = authorId;
            _removingMemberId = removingMemberId;
        }

        public bool IsBroken() => _removingMemberId != _authorId;

        public string Message => "Only author of post or administrator can remove post comment.";
    }
}