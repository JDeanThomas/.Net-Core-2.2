using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Migrations
{
    public partial class AddedFilmImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FilmImageId",
                table: "film",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_film_FilmImageId",
                table: "film",
                column: "FilmImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_film_FilmImage_FilmImageId",
                table: "film",
                column: "FilmImageId",
                principalTable: "FilmImage",
                principalColumn: "FilmImageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_film_FilmImage_FilmImageId",
                table: "film");

            migrationBuilder.DropIndex(
                name: "IX_film_FilmImageId",
                table: "film");

            migrationBuilder.DropColumn(
                name: "FilmImageId",
                table: "film");
        }
    }
}
