using System;

namespace KavaaBook.Application.Posts.GetMemberPosts
{
    public class MemberPostDto
    {
        public Guid PostId { get; set; }
        public string Text { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; }
    }
}