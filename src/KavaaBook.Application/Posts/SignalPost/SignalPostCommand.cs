using System;
using System.Threading;
using System.Threading.Tasks;
using KavaaBook.Application.SeedWork;
using KavaaBook.Domain.Entities.MemberAggregate;
using KavaaBook.Domain.Entities.PostAggregate;
using MediatR;

namespace KavaaBook.Application.Posts.ChangePostMainAttribut
{
    public class SignalPostCommand : ICommand
    {
        public SignalPostCommand(Guid postId, string reason, Guid memberId)
        {
            Reason = reason;
            MemberId = memberId;
            PostId = postId;
        }

        public string Reason { get; }
        public Guid MemberId { get; }
        public Guid PostId { get; }
    }

    internal class SignalPostCommandHandler : IRequestHandler<SignalPostCommand>
    {
        private readonly IPostRepository _postRepository;

        public SignalPostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Unit> Handle(SignalPostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(new PostId(request.PostId));

            post.SignalPost(new MemberId(request.MemberId), request.Reason);

            return Unit.Value;
        }
    }
}