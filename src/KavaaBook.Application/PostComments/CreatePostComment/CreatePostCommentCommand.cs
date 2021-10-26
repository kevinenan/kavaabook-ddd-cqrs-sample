using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KavaaBook.Application.SeedWork;
using KavaaBook.Domain.Entities.PostAggregate;
using KavaaBook.Domain.Entities.PostCommentAggregate;
using MediatR;

namespace KavaaBook.Application.PostComments.CreatePostComment
{
    public class CreatePostCommentCommand : ICommand<Guid>
    {
        public CreatePostCommentCommand(Guid postId, string comment)
        {
            PostId = postId;
            Comment = comment;
        }

        public Guid PostId { get; }

        public string Comment { get; }
        public Guid MemberId { get; }
    }

    internal class CreatePostCommentCommandHandler : IRequestHandler<CreatePostCommentCommand, Guid>
    {
        private readonly IPostCommentRepository _postCommentRepository;
        private readonly IPostRepository _postRepository;

        public CreatePostCommentCommandHandler(
            IPostCommentRepository postCommentRepository,
            IPostRepository postRepository)
        {
            _postCommentRepository = postCommentRepository;
            _postRepository = postRepository;
        }

        public async Task<Guid> Handle(CreatePostCommentCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(new PostId(request.PostId));
            if (post == null)
            {
                throw new InvalidCommandException(new List<string> { "Post for adding comment must exist." });
            }

            var postComment = post.AddComment(new Domain.Entities.MemberAggregate.MemberId(request.MemberId), request.Comment);

            await _postCommentRepository.AddAsync(postComment);

            return postComment.Id.Value;
        }
    }
}