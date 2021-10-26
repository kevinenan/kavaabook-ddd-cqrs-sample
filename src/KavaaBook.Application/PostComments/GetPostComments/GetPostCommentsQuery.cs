using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KavaaBook.Application.SeedWork;
using KavaaBook.Application.Data;
using Dapper;
using MediatR;

namespace KavaaBook.Application.PostComments.GetPostComments
{
    public class GetPostCommentsQuery : IQuery<List<PostCommentDto>>
    {
        public GetPostCommentsQuery(Guid postId)
        {
            PostId = postId;
        }

        public Guid PostId { get; }
    }

    internal class GetPostCommentsQueryHandler : IRequestHandler<GetPostCommentsQuery, List<PostCommentDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetPostCommentsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<List<PostCommentDto>> Handle(GetPostCommentsQuery query, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            string sql = "SELECT " +
                         $"[PostComment].[Id] AS [{nameof(PostCommentDto.Id)}], " +
                         $"[PostComment].[AuthorId] AS [{nameof(PostCommentDto.AuthorId)}], " +
                         $"[PostComment].[Comment] AS [{nameof(PostCommentDto.Comment)}], " +
                         $"[PostComment].[CreateDate] AS [{nameof(PostCommentDto.CreateDate)}], " +
                         $"[PostComment].[EditDate] AS [{nameof(PostCommentDto.EditDate)}] " +
                         "FROM [posts].[PostComments] AS [PostComment]" +
                         "WHERE [PostComment].[PostId] = @PostId";

            var postComments = await connection.QueryAsync<PostCommentDto>(sql, new { query.PostId });

            return postComments.AsList();
        }
    }
}