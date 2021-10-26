using System;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using KavaaBook.Application.Data;
using KavaaBook.Application.SeedWork;
using MediatR;

namespace KavaaBook.Application.Posts.GetPostDetails
{
    public class GetPostDetailsQuery : IQuery<PostDetailsDto>
    {
        public GetPostDetailsQuery(Guid postId)
        {
            PostId = postId;
        }

        public Guid PostId { get; }
    }

    internal class GetPostDetailsQueryHandler : IRequestHandler<GetPostDetailsQuery, PostDetailsDto>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetPostDetailsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<PostDetailsDto> Handle(GetPostDetailsQuery request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            return await connection.QuerySingleOrDefaultAsync<PostDetailsDto>(
                "SELECT " +
                $"[PostDetails].[Id] AS [{nameof(PostDetailsDto.PostId)}]," +
                $"[PostDetails].[CreateDate] AS [{nameof(PostDetailsDto.CreateDate)}]," +
                $"[PostDetails].[Status] AS [{nameof(PostDetailsDto.Status)}]," +
                $"[PostDetails].[Text] AS [{nameof(PostDetailsDto.Text)}]" +
                "FROM [posts].[Posts] AS [PostDetails] " +
                "WHERE [PostDetails].[Id] = @PostId AND [PostDetails].[IsRemoved] = 0",
                new
                {
                    PostId = request.PostId
                });
        }
    }
}