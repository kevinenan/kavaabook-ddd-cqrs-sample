using System;
using System.Threading;
using System.Threading.Tasks;
using KavaaBook.Application.SeedWork;
using KavaaBook.Domain.Entities.PostAggregate;
using MediatR;

namespace KavaaBook.Application.Posts.DeletePost
{
    public class DeletePostCommand : ICommand
    {
        public DeletePostCommand(Guid postId, Guid memberId)
        {
            PostId = postId;
            MemberId = memberId;
        }

        public Guid PostId { get; }
        public Guid MemberId { get; }
    }

    internal class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IPostRepository _postRepository;

        public DeletePostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(new PostId(request.PostId));

            post.Remove(new Domain.Entities.MemberAggregate.MemberId(request.MemberId));

            return Unit.Value;
        }
    }
}