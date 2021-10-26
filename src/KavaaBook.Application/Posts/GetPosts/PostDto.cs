using System;
using KavaaBook.Domain.Entities.PostAggregate;

namespace KavaaBook.Application.Posts.GetMemberPosts
{
    public class PostDto
    {
        public Guid PostId { get; set; }
        public string Text { get; set; }
        public PostStatus Status { get; set; }
        public DateTime CreateDate { get; }
    }
}