using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Migrations
{
    public partial class AddedRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "film",
                newName: "RatingCode");

            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "film",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    RatingId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.RatingId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_film_RatingId",
                table: "film",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_film_Rating_RatingId",
                table: "film",
                column: "RatingId",
                principalTable: "Rating",
                principalColumn: "RatingId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_film_Rating_RatingId",
                table: "film");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_film_RatingId",
                table: "film");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "film");

            migrationBuilder.RenameColumn(
                name: "RatingCode",
                table: "film",
                newName: "Rating");
        }
    }
}
