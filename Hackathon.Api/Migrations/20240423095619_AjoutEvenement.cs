using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hackathon.Api.Migrations
{
    /// <inheritdoc />
    public partial class AjoutEvenement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtelierVisiteurs_Ateliers_AtelierId",
                table: "AtelierVisiteurs");

            migrationBuilder.DropForeignKey(
                name: "FK_Ateliers_Ecoles_EcoleId",
                table: "Ateliers");

            migrationBuilder.DropIndex(
                name: "IX_Ateliers_EcoleId",
                table: "Ateliers");

            migrationBuilder.DropColumn(
                name: "Date_End",
                table: "Ateliers");

            migrationBuilder.DropColumn(
                name: "Date_limit",
                table: "Ateliers");

            migrationBuilder.DropColumn(
                name: "Date_start",
                table: "Ateliers");

            migrationBuilder.DropColumn(
                name: "EcoleId",
                table: "Ateliers");

            migrationBuilder.DropColumn(
                name: "Nombre_participant",
                table: "Ateliers");

            migrationBuilder.RenameColumn(
                name: "AtelierId",
                table: "AtelierVisiteurs",
                newName: "EvenementId");

            migrationBuilder.CreateTable(
                name: "Evenements",
                columns: table => new
                {
                    EvenementId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EvenementName = table.Column<string>(type: "text", nullable: false),
                    DateDebut = table.Column<string>(type: "text", nullable: false),
                    DateFin = table.Column<string>(type: "text", nullable: false),
                    DateLimit = table.Column<string>(type: "text", nullable: false),
                    Localisation = table.Column<string>(type: "text", nullable: false),
                    NombreParticipant = table.Column<int>(type: "integer", nullable: false),
                    Prix = table.Column<decimal>(type: "numeric", nullable: false),
                    EcoleId = table.Column<int>(type: "integer", nullable: true),
                    AtelierId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evenements", x => x.EvenementId);
                    table.ForeignKey(
                        name: "FK_Evenements_Ateliers_AtelierId",
                        column: x => x.AtelierId,
                        principalTable: "Ateliers",
                        principalColumn: "AtelierId");
                    table.ForeignKey(
                        name: "FK_Evenements_Ecoles_EcoleId",
                        column: x => x.EcoleId,
                        principalTable: "Ecoles",
                        principalColumn: "EcoleId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evenements_AtelierId",
                table: "Evenements",
                column: "AtelierId");

            migrationBuilder.CreateIndex(
                name: "IX_Evenements_EcoleId",
                table: "Evenements",
                column: "EcoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtelierVisiteurs_Evenements_EvenementId",
                table: "AtelierVisiteurs",
                column: "EvenementId",
                principalTable: "Evenements",
                principalColumn: "EvenementId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtelierVisiteurs_Evenements_EvenementId",
                table: "AtelierVisiteurs");

            migrationBuilder.DropTable(
                name: "Evenements");

            migrationBuilder.RenameColumn(
                name: "EvenementId",
                table: "AtelierVisiteurs",
                newName: "AtelierId");

            migrationBuilder.AddColumn<string>(
                name: "Date_End",
                table: "Ateliers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Date_limit",
                table: "Ateliers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Date_start",
                table: "Ateliers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EcoleId",
                table: "Ateliers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Nombre_participant",
                table: "Ateliers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ateliers_EcoleId",
                table: "Ateliers",
                column: "EcoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtelierVisiteurs_Ateliers_AtelierId",
                table: "AtelierVisiteurs",
                column: "AtelierId",
                principalTable: "Ateliers",
                principalColumn: "AtelierId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ateliers_Ecoles_EcoleId",
                table: "Ateliers",
                column: "EcoleId",
                principalTable: "Ecoles",
                principalColumn: "EcoleId");
        }
    }
}
