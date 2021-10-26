using System;
using KavaaBook.Domain.SeedWork;

namespace KavaaBook.Domain.Entities.MemberAggregate
{
    public class MemberId : TypedIdValueBase
    {
        public MemberId(Guid value) : base(value)
        {
        }
    }
}