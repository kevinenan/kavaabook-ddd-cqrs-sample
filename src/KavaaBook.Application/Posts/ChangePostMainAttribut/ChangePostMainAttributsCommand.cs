using System;
using System.Threading;
using System.Threading.Tasks;
using KavaaBook.Application.SeedWork;
using KavaaBook.Domain.Entities.MemberAggregate;
using KavaaBook.Domain.Entities.PostAggregate;
using MediatR;

namespace KavaaBook.Application.Posts.ChangePostMainAttribut
{
    public class ChangePostMainAttributsCommand : ICommand
    {
        public ChangePostMainAttributsCommand(string text, Guid memberId, Guid postId)
        {
            EditedText = text;
            MemberId = memberId;
            PostId = postId;
        }

        public string EditedText { get; }
        public Guid MemberId { get; }
        public Guid PostId { get; }
    }

    internal class ChangePostMainAttributCommandHandler : IRequestHandler<ChangePostMainAttributsCommand>
    {
        private readonly IPostRepository _postRepository;

        public ChangePostMainAttributCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Unit> Handle(ChangePostMainAttributsCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(new PostId(request.PostId));

            post.Edit(new MemberId(request.MemberId), request.EditedText);

            return Unit.Value;
        }
    }
}