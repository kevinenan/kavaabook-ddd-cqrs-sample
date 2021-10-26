using System.Threading.Tasks;

namespace KavaaBook.Domain.Entities.PostAggregate
{
    public interface IPostRepository
    {
        Task AddAsync(Post meetingGroup);

        Task<Post> GetByIdAsync(PostId id);
    }
}