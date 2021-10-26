using System;
using KavaaBook.Domain.Entities.MemberAggregate;
using KavaaBook.Domain.Entities.PostAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KavaaBook.Persistence.Domain.Posts
{
    internal class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts", "posts");

            builder.HasKey(x => x.Id);

            builder.Property<string>("_text").HasColumnName("Text");
            builder.Property<PostStatus>("_status").HasColumnName("Status");
            builder.Property<DateTime>("_createDate").HasColumnName("CreateDate");
            builder.Property<MemberId>("_authorId").HasColumnName("AuthorId");
            builder.Property<DateTime?>("_editDate").HasColumnName("EditDate");
            builder.Property<bool>("_isRemoved").HasColumnName("IsRemoved");
            builder.Property<string>("_removedByReason").HasColumnName("RemovedByReason");

            builder.OwnsMany<PostSignal>("_postSignals", y =>
            {
                y.WithOwner().HasForeignKey("PostId");

                y.ToTable("PostSignals", "posts");

                y.Property<MemberId>("SignalorId");
                y.Property<PostId>("PostId");
                y.Property<string>("_reason").HasColumnName("Reason");
                y.Property<DateTime>("_signalDate").HasColumnName("SignalDate");
                y.HasKey("SignalorId", "PostId", "_signalDate");
            });

            builder.OwnsMany<PostReact>("_postReacts", y =>
            {
                y.WithOwner().HasForeignKey("PostId");

                y.ToTable("PostReacts", "posts");

                y.Property<MemberId>("ReactorId");
                y.Property<PostId>("PostId");
                y.Property<ReactType>("_reactType").HasColumnName("ReactType");
                y.Property<DateTime>("_reactionDate").HasColumnName("ReactionDate");
                y.HasKey("ReactorId", "PostId", "_reactionDate");
            });
        }
    }
}