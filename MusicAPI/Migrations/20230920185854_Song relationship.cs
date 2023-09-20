using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicAPI.Migrations
{
    /// <inheritdoc />
    public partial class Songrelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenresId",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_GenresId",
                table: "Songs",
                column: "GenresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Genres_GenresId",
                table: "Songs",
                column: "GenresId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Genres_GenresId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_GenresId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "GenresId",
                table: "Songs");
        }
    }
}
