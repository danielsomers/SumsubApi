using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sumsub.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReviewResults",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModerationComment = table.Column<string>(type: "TEXT", nullable: false),
                    ClientComment = table.Column<string>(type: "TEXT", nullable: false),
                    ReviewAnswer = table.Column<string>(type: "TEXT", nullable: false),
                    RejectLabels = table.Column<string>(type: "TEXT", nullable: false),
                    ReviewRejectType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    InspectionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CorrelationId = table.Column<string>(type: "TEXT", nullable: false),
                    LevelName = table.Column<string>(type: "TEXT", nullable: false),
                    ExternalUserId = table.Column<long>(type: "INTEGER", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    SandboxMode = table.Column<string>(type: "TEXT", nullable: false),
                    ReviewStatus = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedAtMs = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ClientId = table.Column<string>(type: "TEXT", nullable: false),
                    ReviewResultId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applicants_ReviewResults_ReviewResultId",
                        column: x => x.ReviewResultId,
                        principalTable: "ReviewResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_ReviewResultId",
                table: "Applicants",
                column: "ReviewResultId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "ReviewResults");
        }
    }
}
