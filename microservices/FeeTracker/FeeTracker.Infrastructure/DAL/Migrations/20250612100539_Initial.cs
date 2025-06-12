using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeeTracker.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeeContributors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeContributors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeePurposeOwners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeePurposeOwners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeePurposes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeePurposes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeePurposes_FeePurposeOwners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "FeePurposeOwners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeeParticipants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FeePurposeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContributorId = table.Column<Guid>(type: "uuid", nullable: false),
                    HasPaid = table.Column<bool>(type: "boolean", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeeParticipants_FeeContributors_ContributorId",
                        column: x => x.ContributorId,
                        principalTable: "FeeContributors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeeParticipants_FeePurposes_FeePurposeId",
                        column: x => x.FeePurposeId,
                        principalTable: "FeePurposes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeeParticipants_ContributorId",
                table: "FeeParticipants",
                column: "ContributorId");

            migrationBuilder.CreateIndex(
                name: "IX_FeeParticipants_FeePurposeId",
                table: "FeeParticipants",
                column: "FeePurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_FeePurposes_OwnerId",
                table: "FeePurposes",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeeParticipants");

            migrationBuilder.DropTable(
                name: "FeeContributors");

            migrationBuilder.DropTable(
                name: "FeePurposes");

            migrationBuilder.DropTable(
                name: "FeePurposeOwners");
        }
    }
}
