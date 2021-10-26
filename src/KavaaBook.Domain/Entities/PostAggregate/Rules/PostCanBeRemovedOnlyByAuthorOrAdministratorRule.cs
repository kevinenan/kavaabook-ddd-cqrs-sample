using KavaaBook.Domain.SeedWork;
using KavaaBook.Domain.Entities.MemberAggregate;

namespace KavaaBook.Domain.Entities.PostAggregate.Rules
{
    public class PostCanBeRemovedOnlyByAuthorOrAdministratorRule : IBusinessRule
    {
        private readonly MemberId _authorId;
        private readonly MemberId _removingMemberId;

        public PostCanBeRemovedOnlyByAuthorOrAdministratorRule(MemberId authorId, MemberId removingMemberId)
        {
            _authorId = authorId;
            _removingMemberId = removingMemberId;
        }

        public bool IsBroken() => _removingMemberId != _authorId;

        public string Message => "Only author of post or administrator can remove post.";
    }
}