using System;
using System.Threading;
using System.Threading.Tasks;
using KavaaBook.Application.SeedWork;
using KavaaBook.Domain.Entities.PostCommentAggregate;
using MediatR;

namespace KavaaBook.Application.PostComments.RemovePostComment
{
    public class RemovePostCommentCommand : ICommand
    {
        public RemovePostCommentCommand(Guid postCommentId, string reason)
        {
            PostCommentId = postCommentId;
            Reason = reason;
        }

        public Guid PostCommentId { get; }

        public string Reason { get; }
        public Guid MemberId { get; }
    }

    internal class RemovePostCommentCommandHandler : IRequestHandler<RemovePostCommentCommand>
    {
        private readonly IPostCommentRepository _postCommentRepository;

        public RemovePostCommentCommandHandler(
            IPostCommentRepository postCommentRepository)
        {
            _postCommentRepository = postCommentRepository;
        }

        public async Task<Unit> Handle(RemovePostCommentCommand request, CancellationToken cancellationToken)
        {
            var postComment = await _postCommentRepository.GetByIdAsync(new PostCommentId(request.PostCommentId));

            postComment.Remove(new Domain.Entities.MemberAggregate.MemberId(request.MemberId));

            return Unit.Value;
        }
    }
}