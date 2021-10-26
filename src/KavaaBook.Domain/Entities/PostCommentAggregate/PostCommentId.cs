using System;
using KavaaBook.Domain.SeedWork;

namespace KavaaBook.Domain.Entities.PostCommentAggregate
{
    public class PostCommentId : TypedIdValueBase
    {
        public PostCommentId(Guid value) : base(value)
        {
        }
    }
}