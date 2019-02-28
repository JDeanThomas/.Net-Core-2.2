using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Migrations
{
    public partial class AddedFilmInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "filminfo",
                columns: table => new
                {
                    Title = table.Column<string>(nullable: false),
                    ReleaseYear = table.Column<int>(nullable: false),
                    Rating = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filminfo", x => new { x.Title, x.ReleaseYear });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "filminfo");
        }
    }
}
