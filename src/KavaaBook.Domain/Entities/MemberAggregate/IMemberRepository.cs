using System.Threading.Tasks;

namespace KavaaBook.Domain.Entities.MemberAggregate
{
    public interface IMemberRepository
    {
        Task AddAsync(Member member);

        Task<Member> GetByIdAsync(MemberId memberId);
    }
}