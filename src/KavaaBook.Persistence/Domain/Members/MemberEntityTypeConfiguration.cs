using System;
using KavaaBook.Domain.Entities.MemberAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KavaaBook.Persistence.Domain.Members
{
    internal class MemberEntityTypeConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Members", "posts");

            builder.HasKey(x => x.Id);

            builder.Property<string>("_userName").HasColumnName("UserName");
            builder.Property<string>("_email").HasColumnName("Email");
            builder.Property<string>("_firstName").HasColumnName("FirstName");
            builder.Property<string>("_lastName").HasColumnName("LastName");
            builder.Property<string>("_name").HasColumnName("Name");

            builder.Property<DateTime>("_createDate").HasColumnName("CreateDate");
            builder.Property<bool>("_isActived").HasColumnName("IsActived");
            builder.Property<string>("_disActivedByReason").HasColumnName("DisActivedByReason");

            builder.OwnsMany<MemberSignal>("_memberSignals", y =>
            {
                y.WithOwner().HasForeignKey("SignaledId");

                y.ToTable("MemberSignals", "posts");

                y.Property<MemberId>("SignaledId");
                y.Property<MemberId>("SignalorId");
                y.Property<string>("_reason").HasColumnName("Reason");
                y.Property<DateTime>("_signalDate").HasColumnName("SignalDate");
                y.HasKey("SignaledId", "SignalorId", "_signalDate");
            });
        }
    }
}