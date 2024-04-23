using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEventVisiteur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtelierVisiteurs_Evenements_EvenementId",
                table: "AtelierVisiteurs");

            migrationBuilder.DropForeignKey(
                name: "FK_AtelierVisiteurs_Visiteurs_VisiteurId",
                table: "AtelierVisiteurs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AtelierVisiteurs",
                table: "AtelierVisiteurs");

            migrationBuilder.RenameTable(
                name: "AtelierVisiteurs",
                newName: "EvenementVisiteur");

            migrationBuilder.RenameIndex(
                name: "IX_AtelierVisiteurs_VisiteurId",
                table: "EvenementVisiteur",
                newName: "IX_EvenementVisiteur_VisiteurId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EvenementVisiteur",
                table: "EvenementVisiteur",
                columns: new[] { "EvenementId", "VisiteurId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EvenementVisiteur_Evenements_EvenementId",
                table: "EvenementVisiteur",
                column: "EvenementId",
                principalTable: "Evenements",
                principalColumn: "EvenementId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EvenementVisiteur_Visiteurs_VisiteurId",
                table: "EvenementVisiteur",
                column: "VisiteurId",
                principalTable: "Visiteurs",
                principalColumn: "VisiteurId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvenementVisiteur_Evenements_EvenementId",
                table: "EvenementVisiteur");

            migrationBuilder.DropForeignKey(
                name: "FK_EvenementVisiteur_Visiteurs_VisiteurId",
                table: "EvenementVisiteur");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EvenementVisiteur",
                table: "EvenementVisiteur");

            migrationBuilder.RenameTable(
                name: "EvenementVisiteur",
                newName: "AtelierVisiteurs");

            migrationBuilder.RenameIndex(
                name: "IX_EvenementVisiteur_VisiteurId",
                table: "AtelierVisiteurs",
                newName: "IX_AtelierVisiteurs_VisiteurId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AtelierVisiteurs",
                table: "AtelierVisiteurs",
                columns: new[] { "EvenementId", "VisiteurId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AtelierVisiteurs_Evenements_EvenementId",
                table: "AtelierVisiteurs",
                column: "EvenementId",
                principalTable: "Evenements",
                principalColumn: "EvenementId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtelierVisiteurs_Visiteurs_VisiteurId",
                table: "AtelierVisiteurs",
                column: "VisiteurId",
                principalTable: "Visiteurs",
                principalColumn: "VisiteurId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
