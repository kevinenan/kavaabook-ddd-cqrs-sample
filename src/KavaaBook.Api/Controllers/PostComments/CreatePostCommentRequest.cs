using System;

namespace KavaaBook.Api.Controllers.PostComments
{
    public class CreatePostCommentRequest
    {
        public Guid PostId { get; set; }

        public string Comment { get; set; }
    }
}