using System;
using System.Threading.Tasks;
using KavaaBook.Application.PostComments.CreatePostComment;
using KavaaBook.Application.PostComments.EditPostComment;
using KavaaBook.Application.PostComments.GetPostComments;
using KavaaBook.Application.PostComments.RemovePostComment;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KavaaBook.Api.Controllers.PostComments
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostCommentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PostCommentsController> _logger;

        public PostCommentsController(
            IMediator mediator,
            ILogger<PostCommentsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("{postId}")]
        public async Task<ActionResult<PostCommentDto>> GetPostDetails(Guid postId)
        {
            var postComments = await _mediator.Send(new GetPostCommentsQuery(postId));
            return Ok(postComments);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddComment([FromBody] CreatePostCommentRequest request)
        {
            var commentId =
                await _mediator.Send(new CreatePostCommentCommand(
                    request.PostId,
                    request.Comment));

            return Ok(commentId);
        }

        [HttpPut("{postCommentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> EditComment(
            [FromRoute] Guid postCommentId,
            [FromBody] EditPostCommentRequest request)
        {
            await _mediator.Send(new EditPostCommentCommand(
                postCommentId,
                request.EditedComment));

            return Ok();
        }

        [HttpDelete("{postCommentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteComment([FromRoute] Guid postCommentId, [FromQuery] string reason)
        {
            await _mediator.Send(
                new RemovePostCommentCommand(postCommentId, reason));

            return Ok();
        }
    }
}