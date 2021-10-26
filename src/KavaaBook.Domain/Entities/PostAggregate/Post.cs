using System;
using System.Collections.Generic;
using KavaaBook.Domain.Entities.MemberAggregate;
using KavaaBook.Domain.Entities.PostAggregate.Events;
using KavaaBook.Domain.Entities.PostAggregate.Rules;
using KavaaBook.Domain.Entities.PostCommentAggregate;
using KavaaBook.Domain.SeedWork;

namespace KavaaBook.Domain.Entities.PostAggregate
{
    public class Post : Entity<PostId>, IAggregateRoot
    {
        private string _text;
        private PostStatus _status;
        private DateTime _createDate;
        private MemberId _authorId;
        private DateTime? _editDate;
        private bool _isRemoved;
        private string _removedByReason;
        private List<PostReact> _postReacts;
        private List<PostSignal> _postSignals;

        private Post()
        {
            // required by EF
            _postReacts = new List<PostReact>();
            _postSignals = new List<PostSignal>();
        }

        public Post(string text, MemberId authorId)
            : this(text, authorId, PostStatus.New)
        {
        }

        private Post(string text, MemberId authorId, PostStatus status)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException($"'{nameof(text)}' cannot be null or empty.", nameof(text));

            if (authorId == null)
                throw new ArgumentException($"'{nameof(_authorId)}' cannot be null or empty.", nameof(_authorId));

            Id = new PostId(Guid.NewGuid());
            _text = text;
            _status = status;
            _authorId = authorId;
            _createDate = DateTime.Now;
            _editDate = null;
            _isRemoved = false;
        }

        public void Edit(MemberId editorId, string editedText)
        {
            CheckRule(new PostCanBeEditedOnlyByAuthorRule(_authorId, editorId));

            _text = editedText;
            _editDate = DateTime.Now;

            _status = PostStatus.Edited;

            AddDomainEvent(new PostEditedDomainEvent(Id, editedText));
        }

        public void Remove(MemberId removerId, string reason = null)
        {
            CheckRule(new PostCanBeRemovedOnlyByAuthorOrAdministratorRule(_authorId, removerId));
            _isRemoved = true;
            _removedByReason = reason ?? string.Empty;

            AddDomainEvent(new PostRemovedDomainEvent(Id));
        }

        public void ReactToPost(MemberId memberId, ReactType reactType)
        {
            var react = _postReacts.Find(e => e.ReactorId == memberId);

            if (react != null)
            {
                _postReacts.Remove(react);
            }
            _postReacts.Add(new PostReact(Id, memberId, reactType));
        }

        public PostComment AddComment(MemberId authorId, string comment)
            => new PostComment(Id, authorId, comment);

        public void SignalPost(MemberId memberId, string reason)
        {
            _postSignals.Add(new PostSignal(Id, memberId, reason));
        }

        public bool IsSignaled() => _postSignals.Count > 0;

        public int TotalReact() => _postReacts.Count;
    }
}