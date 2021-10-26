using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KavaaBook.Application.SeedWork;
using KavaaBook.Application.Data;
using Dapper;
using MediatR;

namespace KavaaBook.Application.Posts.GetMemberPosts
{
    public class GetPostsQuery : IQuery<List<PostDto>>
    {
    }

    internal class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, List<PostDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetPostsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<List<PostDto>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            return (await connection.QueryAsync<PostDto>(
                "SELECT " +
                $"[Post].[Id] AS [{nameof(PostDto.PostId)}]," +
                $"[Post].[CreateDate] AS [{nameof(PostDto.CreateDate)}]," +
                $"[Post].[Status] AS [{nameof(PostDto.Status)}]," +
                $"[Post].[Text] AS [{nameof(PostDto.Text)}]" +
                "FROM [posts].[Posts] AS [Post] " +
                "WHERE [Post].[IsRemoved] = 0")).AsList();
        }
    }
}