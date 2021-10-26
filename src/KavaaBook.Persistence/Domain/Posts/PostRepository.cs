using System.Threading.Tasks;
using KavaaBook.Domain.Entities.PostAggregate;

namespace KavaaBook.Persistence.Domain.Posts
{
    internal class PostRepository : IPostRepository
    {
        private readonly BookContext _bookContext;

        public PostRepository(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public async Task AddAsync(Post post)
        {
            await _bookContext.Posts.AddAsync(post);
        }

        public async Task<Post> GetByIdAsync(PostId id)
        {
            return await _bookContext.Posts.FindAsync(id);
        }
    }
}