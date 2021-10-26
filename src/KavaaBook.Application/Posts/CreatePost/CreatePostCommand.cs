using System;
using System.Threading;
using System.Threading.Tasks;
using KavaaBook.Application.SeedWork;
using KavaaBook.Domain.Entities.MemberAggregate;
using KavaaBook.Domain.Entities.PostAggregate;
using FluentValidation;
using MediatR;

namespace KavaaBook.Application.Posts.CreatePost
{
    public class CreatePostCommand : ICommand<Guid>
    {
        public CreatePostCommand(Guid memberId, string text)
        {
            Text = text;
            MemberId = memberId;
        }

        public string Text { get; }
        public Guid MemberId { get; }
    }

    internal class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(c => c.Text).NotNull().NotEmpty()
                .WithMessage("Text cannot be null or empty.");
        }
    }

    internal class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Guid>
    {
        private readonly IPostRepository _postRepository;

        public CreatePostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = new Post(request.Text, new MemberId(request.MemberId));
            await _postRepository.AddAsync(post);

            return post.Id.Value;
        }
    }
}