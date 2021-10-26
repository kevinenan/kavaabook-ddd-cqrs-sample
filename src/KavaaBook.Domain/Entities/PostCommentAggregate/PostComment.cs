using System;
using KavaaBook.Domain.Entities.MemberAggregate;
using KavaaBook.Domain.Entities.PostAggregate;
using KavaaBook.Domain.Entities.PostCommentAggregate.Events;
using KavaaBook.Domain.Entities.PostCommentAggregate.Rules;
using KavaaBook.Domain.SeedWork;

namespace KavaaBook.Domain.Entities.PostCommentAggregate
{
    public class PostComment : Entity<PostCommentId>, IAggregateRoot
    {
        private PostId _postId;

        private MemberId _authorId;
        private string _comment;

        private DateTime _createDate;

        private DateTime? _editDate;

        private bool _isRemoved;

        private string _removedByReason;

        private PostComment()
        {
            // Only for EF.
        }

        internal PostComment(PostId postId, MemberId authorId, string comment)
        {
            Id = new PostCommentId(Guid.NewGuid());
            _postId = postId;
            _authorId = authorId;
            _comment = comment;

            _createDate = DateTime.Now;
            _editDate = null;

            _isRemoved = false;
            _removedByReason = null;

            AddDomainEvent(new PostCommentAddedDomainEvent(Id, _postId, comment));
        }

        public void Edit(MemberId editorId, string editedComment)
        {
            CheckRule(new PostCommentCanBeEditedOnlyByAuthorRule(_authorId, editorId));

            _comment = editedComment;
            _editDate = DateTime.Now;

            AddDomainEvent(new PostCommentEditedDomainEvent(Id, editedComment));
        }

        public void Remove(MemberId removerId, string reason = null)
        {
            CheckRule(new PostCommentCanBeRemovedOnlyByAuthorOrAdministratorRule(_authorId, removerId));
            _isRemoved = true;
            _removedByReason = reason ?? string.Empty;

            AddDomainEvent(new PostCommentRemovedDomainEvent(Id));
        }
    }
}