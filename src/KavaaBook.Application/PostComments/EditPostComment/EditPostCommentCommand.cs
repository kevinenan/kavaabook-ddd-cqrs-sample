using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KavaaBook.Application.SeedWork;
using KavaaBook.Domain.Entities.PostCommentAggregate;
using MediatR;

namespace KavaaBook.Application.PostComments.EditPostComment
{
    public class EditPostCommentCommand : ICommand
    {
        public EditPostCommentCommand(Guid postCommentId, string editedComment)
        {
            PostCommentId = postCommentId;
            EditedComment = editedComment;
        }

        public Guid PostCommentId { get; }

        public string EditedComment { get; }
        public Guid MemberId { get; }
    }

    internal class EditPostCommentCommandhandler : ICommandHandler<EditPostCommentCommand>
    {
        private readonly IPostCommentRepository _postCommentRepository;

        public EditPostCommentCommandhandler(
            IPostCommentRepository postCommentRepository)
        {
            _postCommentRepository = postCommentRepository;
        }

        public async Task<Unit> Handle(EditPostCommentCommand request, CancellationToken cancellationToken)
        {
            var postComment = await _postCommentRepository.GetByIdAsync(new PostCommentId(request.PostCommentId));
            if (postComment == null)
            {
                throw new InvalidCommandException(new List<string> { "Post for adding comment must exist." });
            }
            postComment.Edit(new Domain.Entities.MemberAggregate.MemberId(request.MemberId), request.EditedComment);

            await _postCommentRepository.AddAsync(postComment);

            return Unit.Value;
        }
    }
}