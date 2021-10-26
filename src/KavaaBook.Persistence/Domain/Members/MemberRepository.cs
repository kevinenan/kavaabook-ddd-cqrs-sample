using System.Threading.Tasks;
using KavaaBook.Domain.Entities.MemberAggregate;
using Microsoft.EntityFrameworkCore;

namespace KavaaBook.Persistence.Domain.Members
{
    internal class MemberRepository : IMemberRepository
    {
        private readonly BookContext _bookContext;

        public MemberRepository(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public async Task AddAsync(Member member)
        {
            await _bookContext.Members.AddAsync(member);
        }

        public async Task<Member> GetByIdAsync(MemberId memberId)
        {
            return await _bookContext.Members.FirstOrDefaultAsync(x => x.Id == memberId);
        }
    }
}