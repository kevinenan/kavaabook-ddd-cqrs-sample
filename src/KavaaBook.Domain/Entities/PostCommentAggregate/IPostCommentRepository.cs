using System.Threading.Tasks;

namespace KavaaBook.Domain.Entities.PostCommentAggregate
{
    public interface IPostCommentRepository
    {
        Task AddAsync(PostComment postComment);

        Task<PostComment> GetByIdAsync(PostCommentId postCommentId);
    }
}