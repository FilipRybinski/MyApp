using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeeTracker.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class IsCompleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "FeePurposes",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "FeePurposes");
        }
    }
}
