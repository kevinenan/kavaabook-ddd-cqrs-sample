using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KavaaBook.Persistence.Migrations
{
    public partial class AddOthersClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReationDate",
                schema: "posts",
                table: "PostReacts",
                newName: "ReactionDate");

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                schema: "posts",
                table: "PostSignals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReactType",
                schema: "posts",
                table: "PostReacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Members",
                schema: "posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisActivedByReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostComments",
                schema: "posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RemovedByReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostComments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberSignals",
                schema: "posts",
                columns: table => new
                {
                    SignalorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SignaledId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SignalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberSignals", x => new { x.SignaledId, x.SignalorId, x.SignalDate });
                    table.ForeignKey(
                        name: "FK_MemberSignals_Members_SignaledId",
                        column: x => x.SignaledId,
                        principalSchema: "posts",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberSignals",
                schema: "posts");

            migrationBuilder.DropTable(
                name: "PostComments",
                schema: "posts");

            migrationBuilder.DropTable(
                name: "Members",
                schema: "posts");

            migrationBuilder.DropColumn(
                name: "Reason",
                schema: "posts",
                table: "PostSignals");

            migrationBuilder.DropColumn(
                name: "ReactType",
                schema: "posts",
                table: "PostReacts");

            migrationBuilder.RenameColumn(
                name: "ReactionDate",
                schema: "posts",
                table: "PostReacts",
                newName: "ReationDate");
        }
    }
}
