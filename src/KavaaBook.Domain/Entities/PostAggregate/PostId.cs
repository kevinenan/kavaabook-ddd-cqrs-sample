using System;
using KavaaBook.Domain.SeedWork;

namespace KavaaBook.Domain.Entities.PostAggregate
{
    public class PostId : TypedIdValueBase
    {
        public PostId(Guid value) : base(value)
        {
        }
    }
}