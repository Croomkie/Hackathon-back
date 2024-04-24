using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.Api.Migrations
{
    /// <inheritdoc />
    public partial class DescriptionAtelierEvenement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Evenements",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Ateliers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Evenements");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Ateliers");
        }
    }
}
