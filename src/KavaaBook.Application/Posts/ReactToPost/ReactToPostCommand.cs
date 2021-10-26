using System;
using System.Threading;
using System.Threading.Tasks;
using KavaaBook.Application.SeedWork;
using KavaaBook.Domain.Entities.MemberAggregate;
using KavaaBook.Domain.Entities.PostAggregate;
using MediatR;

namespace KavaaBook.Application.Posts.ChangePostMainAttribut
{
    public class ReactToPostCommand : ICommand
    {
        public ReactToPostCommand(Guid postId, ReactType reactType, Guid memberId)
        {
            ReactType = reactType;
            MemberId = memberId;
            PostId = postId;
        }

        public ReactType ReactType { get; }
        public Guid MemberId { get; }
        public Guid PostId { get; }
    }

    internal class ReactToPostCommandHandler : IRequestHandler<ReactToPostCommand>
    {
        private readonly IPostRepository _postRepository;

        public ReactToPostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Unit> Handle(ReactToPostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(new PostId(request.PostId));

            post.ReactToPost(new MemberId(request.MemberId), request.ReactType);

            return Unit.Value;
        }
    }

    
}