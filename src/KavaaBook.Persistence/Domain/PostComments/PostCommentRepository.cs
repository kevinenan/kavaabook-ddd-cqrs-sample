using System.Threading.Tasks;
using KavaaBook.Domain.Entities.PostCommentAggregate;

namespace KavaaBook.Persistence.Domain.PostComments
{
    internal class PostCommentRepository : IPostCommentRepository
    {
        private readonly BookContext _bookContext;

        public PostCommentRepository(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public async Task AddAsync(PostComment postComment)
        {
            await _bookContext.PostComments.AddAsync(postComment);
        }

        public async Task<PostComment> GetByIdAsync(PostCommentId postCommentId)
        {
            return await _bookContext.PostComments.FindAsync(postCommentId);
        }
    }
}