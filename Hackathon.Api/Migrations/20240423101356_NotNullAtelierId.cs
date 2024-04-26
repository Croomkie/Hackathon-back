using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.Api.Migrations
{
    /// <inheritdoc />
    public partial class NotNullAtelierId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evenements_Ateliers_AtelierId",
                table: "Evenements");

            migrationBuilder.AlterColumn<int>(
                name: "AtelierId",
                table: "Evenements",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Evenements_Ateliers_AtelierId",
                table: "Evenements",
                column: "AtelierId",
                principalTable: "Ateliers",
                principalColumn: "AtelierId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evenements_Ateliers_AtelierId",
                table: "Evenements");

            migrationBuilder.AlterColumn<int>(
                name: "AtelierId",
                table: "Evenements",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Evenements_Ateliers_AtelierId",
                table: "Evenements",
                column: "AtelierId",
                principalTable: "Ateliers",
                principalColumn: "AtelierId");
        }
    }
}
