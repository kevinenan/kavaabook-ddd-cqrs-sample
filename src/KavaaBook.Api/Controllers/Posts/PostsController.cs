using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KavaaBook.Application.Posts.ChangePostMainAttribut;
using KavaaBook.Application.Posts.CreatePost;
using KavaaBook.Application.Posts.DeletePost;
using KavaaBook.Application.Posts.GetMemberPosts;
using KavaaBook.Application.Posts.GetPostDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KavaaBook.Api.Controllers.Posts
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PostsController> _logger;

        public PostsController(
            IMediator mediator,
            ILogger<PostsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetPosts()
        {
            _logger.LogInformation("Getting all posts");
            var posts = await _mediator.Send(new GetPostsQuery());
            return Ok(posts);
        }

        [HttpGet("membersPosts")]
        public async Task<ActionResult<IEnumerable<MemberPostDto>>> GetMemberPosts()
        {
            _logger.LogInformation("Getting all members posts");
            var posts = await _mediator.Send(new GetMemberPostsQuery(Guid.NewGuid()));
            return Ok(posts);
        }

        [HttpGet("{postId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PostDetailsDto>> GetPostDetails(Guid postId)
        {
            var postDetails = await _mediator.Send(new GetPostDetailsQuery(postId));
            return Ok(postDetails);
        }

        [HttpPost("{postId}/react")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> ReactToPost([FromRoute] Guid postId, [FromBody] ReactToPostRequest request)
        {
            await _mediator.Send(new ReactToPostCommand(postId, request.ReactType, Guid.NewGuid()));
            return Ok();
        }

        [HttpPost("{postId}/signal")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> SignalPost([FromRoute] Guid postId, [FromBody] SignalPostRequest request)
        {
            await _mediator.Send(new SignalPostCommand(postId, request.Reason, Guid.NewGuid()));
            return Ok();
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostRequest request)
        {
            var newPostId = await _mediator.Send(new CreatePostCommand(Guid.NewGuid(), request.Text));
            return Created($"/api/posts/{newPostId}", request);
        }

        [HttpPut("{postId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ChangePostMainAttributs(
            [FromRoute] Guid postId,
            [FromBody] ChangePostMainAttributsRequest request)
        {
            await _mediator.Send(new ChangePostMainAttributsCommand(request.Text, Guid.NewGuid(), postId));
            return Ok();
        }

        [HttpDelete("{postId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePost(Guid postId)
        {
            await _mediator.Send(new DeletePostCommand(postId, Guid.NewGuid()));

            return Ok();
        }
    }
}