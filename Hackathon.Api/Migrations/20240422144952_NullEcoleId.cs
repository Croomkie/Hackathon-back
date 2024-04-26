using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.Api.Migrations
{
    /// <inheritdoc />
    public partial class NullEcoleId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ateliers_Ecoles_EcoleId",
                table: "Ateliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Visiteurs_Ecoles_EcoleId",
                table: "Visiteurs");

            migrationBuilder.AlterColumn<int>(
                name: "EcoleId",
                table: "Visiteurs",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "EcoleId",
                table: "Ateliers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Ateliers_Ecoles_EcoleId",
                table: "Ateliers",
                column: "EcoleId",
                principalTable: "Ecoles",
                principalColumn: "EcoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visiteurs_Ecoles_EcoleId",
                table: "Visiteurs",
                column: "EcoleId",
                principalTable: "Ecoles",
                principalColumn: "EcoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ateliers_Ecoles_EcoleId",
                table: "Ateliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Visiteurs_Ecoles_EcoleId",
                table: "Visiteurs");

            migrationBuilder.AlterColumn<int>(
                name: "EcoleId",
                table: "Visiteurs",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EcoleId",
                table: "Ateliers",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ateliers_Ecoles_EcoleId",
                table: "Ateliers",
                column: "EcoleId",
                principalTable: "Ecoles",
                principalColumn: "EcoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visiteurs_Ecoles_EcoleId",
                table: "Visiteurs",
                column: "EcoleId",
                principalTable: "Ecoles",
                principalColumn: "EcoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
