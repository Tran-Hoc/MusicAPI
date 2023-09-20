using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicAPI.Migrations
{
    /// <inheritdoc />
    public partial class Updateforeignket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdSong",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "IdSong",
                table: "PlayLists");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "PlayLists");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdSong",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSong",
                table: "PlayLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "PlayLists",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
