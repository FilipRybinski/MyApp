using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrashTracker.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlertzyIntegrations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserIdentityId = table.Column<Guid>(type: "uuid", nullable: true),
                    AlertzyKey = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertzyIntegrations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WasteTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WasteTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntegrationLocalities",
                columns: table => new
                {
                    AlertzyIntegrationId = table.Column<Guid>(type: "uuid", nullable: false),
                    LocalityId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrationLocalities", x => new { x.LocalityId, x.AlertzyIntegrationId });
                    table.ForeignKey(
                        name: "FK_IntegrationLocalities_AlertzyIntegrations_AlertzyIntegratio~",
                        column: x => x.AlertzyIntegrationId,
                        principalTable: "AlertzyIntegrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IntegrationLocalities_Localities_LocalityId",
                        column: x => x.LocalityId,
                        principalTable: "Localities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollectionDates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LocalityId = table.Column<Guid>(type: "uuid", nullable: false),
                    WasteTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollectionDates_Localities_LocalityId",
                        column: x => x.LocalityId,
                        principalTable: "Localities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionDates_WasteTypes_WasteTypeId",
                        column: x => x.WasteTypeId,
                        principalTable: "WasteTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionDates_LocalityId",
                table: "CollectionDates",
                column: "LocalityId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionDates_WasteTypeId",
                table: "CollectionDates",
                column: "WasteTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IntegrationLocalities_AlertzyIntegrationId",
                table: "IntegrationLocalities",
                column: "AlertzyIntegrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Localities_Name",
                table: "Localities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WasteTypes_Name",
                table: "WasteTypes",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionDates");

            migrationBuilder.DropTable(
                name: "IntegrationLocalities");

            migrationBuilder.DropTable(
                name: "WasteTypes");

            migrationBuilder.DropTable(
                name: "AlertzyIntegrations");

            migrationBuilder.DropTable(
                name: "Localities");
        }
    }
}
