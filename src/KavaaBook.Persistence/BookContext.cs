using KavaaBook.Domain.Entities.MemberAggregate;
using KavaaBook.Domain.Entities.PostAggregate;
using KavaaBook.Domain.Entities.PostCommentAggregate;
using Microsoft.EntityFrameworkCore;

namespace KavaaBook.Persistence
{
    public class BookContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<PostComment> PostComments { get; set; }

        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}