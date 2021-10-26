﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using KavaaBook.Persistence;

namespace KavaaBook.Persistence.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20211007175438_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.PostAggregate.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("_authorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AuthorId");

                    b.Property<DateTime>("_createDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateDate");

                    b.Property<DateTime?>("_editDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("EditDate");

                    b.Property<bool>("_isRemoved")
                        .HasColumnType("bit")
                        .HasColumnName("IsRemoved");

                    b.Property<string>("_removedByReason")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RemovedByReason");

                    b.Property<int>("_status")
                        .HasColumnType("int")
                        .HasColumnName("Status");

                    b.Property<string>("_text")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Text");

                    b.HasKey("Id");

                    b.ToTable("Posts", "posts");
                });

            modelBuilder.Entity("Domain.Entities.PostAggregate.Post", b =>
                {
                    b.OwnsMany("Domain.Entities.PostAggregate.PostReact", "_postReacts", b1 =>
                        {
                            b1.Property<Guid>("ReactorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("PostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("_reationDate")
                                .HasColumnType("datetime2")
                                .HasColumnName("ReationDate");

                            b1.HasKey("ReactorId", "PostId", "_reationDate");

                            b1.HasIndex("PostId");

                            b1.ToTable("PostReacts", "posts");

                            b1.WithOwner()
                                .HasForeignKey("PostId");
                        });

                    b.OwnsMany("Domain.Entities.PostAggregate.PostSignal", "_postSignals", b1 =>
                        {
                            b1.Property<Guid>("SignalorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("PostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("_signalDate")
                                .HasColumnType("datetime2")
                                .HasColumnName("SignalDate");

                            b1.HasKey("SignalorId", "PostId", "_signalDate");

                            b1.HasIndex("PostId");

                            b1.ToTable("PostSignals", "posts");

                            b1.WithOwner()
                                .HasForeignKey("PostId");
                        });

                    b.Navigation("_postReacts");

                    b.Navigation("_postSignals");
                });
#pragma warning restore 612, 618
        }
    }
}
