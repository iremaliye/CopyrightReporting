using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CopyrightReporting.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateProviders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Provders_ProviderId",
                table: "Musics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Provders",
                table: "Provders");

            migrationBuilder.RenameTable(
                name: "Provders",
                newName: "Providers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Providers",
                table: "Providers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Providers_ProviderId",
                table: "Musics",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Providers_ProviderId",
                table: "Musics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Providers",
                table: "Providers");

            migrationBuilder.RenameTable(
                name: "Providers",
                newName: "Provders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Provders",
                table: "Provders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Provders_ProviderId",
                table: "Musics",
                column: "ProviderId",
                principalTable: "Provders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
