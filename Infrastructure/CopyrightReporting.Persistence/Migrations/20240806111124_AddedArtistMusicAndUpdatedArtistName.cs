using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CopyrightReporting.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedArtistMusicAndUpdatedArtistName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistMusic_Artists_ArtistsId",
                table: "ArtistMusic");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistMusic_Musics_MusicsId",
                table: "ArtistMusic");

            migrationBuilder.RenameColumn(
                name: "MusicsId",
                table: "ArtistMusic",
                newName: "MusicId");

            migrationBuilder.RenameColumn(
                name: "ArtistsId",
                table: "ArtistMusic",
                newName: "ArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_ArtistMusic_MusicsId",
                table: "ArtistMusic",
                newName: "IX_ArtistMusic_MusicId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Artists",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistMusic_Artists_ArtistId",
                table: "ArtistMusic",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistMusic_Musics_MusicId",
                table: "ArtistMusic",
                column: "MusicId",
                principalTable: "Musics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistMusic_Artists_ArtistId",
                table: "ArtistMusic");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistMusic_Musics_MusicId",
                table: "ArtistMusic");

            migrationBuilder.RenameColumn(
                name: "MusicId",
                table: "ArtistMusic",
                newName: "MusicsId");

            migrationBuilder.RenameColumn(
                name: "ArtistId",
                table: "ArtistMusic",
                newName: "ArtistsId");

            migrationBuilder.RenameIndex(
                name: "IX_ArtistMusic_MusicId",
                table: "ArtistMusic",
                newName: "IX_ArtistMusic_MusicsId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Artists",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistMusic_Artists_ArtistsId",
                table: "ArtistMusic",
                column: "ArtistsId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistMusic_Musics_MusicsId",
                table: "ArtistMusic",
                column: "MusicsId",
                principalTable: "Musics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
