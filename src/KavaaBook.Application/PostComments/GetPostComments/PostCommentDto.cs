using System;

namespace KavaaBook.Application.PostComments.GetPostComments
{
    public class PostCommentDto
    {
        public Guid Id { get; }

        public Guid AuthorId { get; }

        public string Comment { get; }

        public DateTime CreateDate { get; }

        public DateTime? EditDate { get; }

        //public int ReactCount { get; }
    }
}