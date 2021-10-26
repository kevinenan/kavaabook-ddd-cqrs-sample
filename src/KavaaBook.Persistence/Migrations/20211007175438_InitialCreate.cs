using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KavaaBook.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "posts");

            migrationBuilder.CreateTable(
                name: "Posts",
                schema: "posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedByReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostReacts",
                schema: "posts",
                columns: table => new
                {
                    ReactorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostReacts", x => new { x.ReactorId, x.PostId, x.ReationDate });
                    table.ForeignKey(
                        name: "FK_PostReacts_Posts_PostId",
                        column: x => x.PostId,
                        principalSchema: "posts",
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostSignals",
                schema: "posts",
                columns: table => new
                {
                    SignalorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SignalDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostSignals", x => new { x.SignalorId, x.PostId, x.SignalDate });
                    table.ForeignKey(
                        name: "FK_PostSignals_Posts_PostId",
                        column: x => x.PostId,
                        principalSchema: "posts",
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostReacts_PostId",
                schema: "posts",
                table: "PostReacts",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostSignals_PostId",
                schema: "posts",
                table: "PostSignals",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostReacts",
                schema: "posts");

            migrationBuilder.DropTable(
                name: "PostSignals",
                schema: "posts");

            migrationBuilder.DropTable(
                name: "Posts",
                schema: "posts");
        }
    }
}
