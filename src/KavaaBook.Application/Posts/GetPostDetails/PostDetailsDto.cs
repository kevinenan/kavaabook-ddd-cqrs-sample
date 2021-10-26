using System;

namespace KavaaBook.Application.Posts.GetPostDetails
{
    public class PostDetailsDto
    {
        public Guid PostId { get; set; }
        public string Text { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; }
    }
}