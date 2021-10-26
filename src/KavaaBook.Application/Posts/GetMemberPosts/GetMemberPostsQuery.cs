using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KavaaBook.Application.SeedWork;
using KavaaBook.Application.Data;
using Dapper;
using MediatR;

namespace KavaaBook.Application.Posts.GetMemberPosts
{
    public class GetMemberPostsQuery : IQuery<List<MemberPostDto>>
    {
        public GetMemberPostsQuery(Guid memberId)
        {
            MemberId = memberId;
        }

        public Guid MemberId { get; }
    }

    internal class GetMemberPostsQueryHandler : IRequestHandler<GetMemberPostsQuery, List<MemberPostDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetMemberPostsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<List<MemberPostDto>> Handle(GetMemberPostsQuery request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            return (await connection.QueryAsync<MemberPostDto>(
                "SELECT " +
                $"[Post].[Id] AS [{nameof(MemberPostDto.PostId)}]," +
                $"[Post].[CreateDate] AS [{nameof(MemberPostDto.CreateDate)}]," +
                $"[Post].[Status] AS [{nameof(MemberPostDto.Status)}]," +
                $"[Post].[Text] AS [{nameof(MemberPostDto.Text)}]" +
                "FROM [posts].[Posts] AS [Post] " +
                "WHERE [Post].[AuthorId] = @AuthorId AND [Post].[IsRemoved] = 0",
                new
                {
                    AuthorId = request.MemberId
                })).AsList();
        }
    }
}