using System;
using KavaaBook.Domain.Entities.MemberAggregate;
using KavaaBook.Domain.Entities.PostAggregate;
using KavaaBook.Domain.Entities.PostCommentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KavaaBook.Persistence.Domain.PostComments
{
    internal class PostCommentEntityTypeConfiguration : IEntityTypeConfiguration<PostComment>
    {
        public void Configure(EntityTypeBuilder<PostComment> builder)
        {
            builder.ToTable("PostComments", "posts");

            builder.HasKey(c => c.Id);

            builder.Property<string>("_comment").HasColumnName("Comment");
            builder.Property<PostId>("_postId").HasColumnName("PostId");
            builder.Property<MemberId>("_authorId").HasColumnName("AuthorId");
            builder.Property<bool>("_isRemoved").HasColumnName("IsRemoved");
            builder.Property<string>("_removedByReason").HasColumnName("RemovedByReason");
            builder.Property<DateTime>("_createDate").HasColumnName("CreateDate");
            builder.Property<DateTime?>("_editDate").HasColumnName("EditDate");
        }
    }
}