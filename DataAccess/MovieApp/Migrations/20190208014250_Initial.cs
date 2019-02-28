using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "actor",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 45, nullable: false),
                    LastName = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actor", x => x.ActorId);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "film",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ReleaseYear = table.Column<int>(type: "int(11)", nullable: true),
                    Rating = table.Column<string>(maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_film", x => x.FilmId);
                });

            migrationBuilder.CreateTable(
                name: "film_actor",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "int(11)", nullable: false),
                    ActorId = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_film_actor", x => new { x.FilmId, x.ActorId });
                    table.ForeignKey(
                        name: "film_actor_actor",
                        column: x => x.ActorId,
                        principalTable: "actor",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "film_actor_film",
                        column: x => x.FilmId,
                        principalTable: "film",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "film_category",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "int(11)", nullable: false),
                    CategoryId = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_film_category", x => new { x.FilmId, x.CategoryId });
                    table.ForeignKey(
                        name: "film_category_category_fk",
                        column: x => x.CategoryId,
                        principalTable: "category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "film_category_film_fk",
                        column: x => x.FilmId,
                        principalTable: "film",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FilmImage",
                columns: table => new
                {
                    FilmImageId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    FilmId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmImage", x => x.FilmImageId);
                    table.ForeignKey(
                        name: "FK_FilmImage_film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "film",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "film_actor_actor_idx",
                table: "film_actor",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "film_category_category_fk_idx",
                table: "film_category",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmImage_FilmId",
                table: "FilmImage",
                column: "FilmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "film_actor");

            migrationBuilder.DropTable(
                name: "film_category");

            migrationBuilder.DropTable(
                name: "FilmImage");

            migrationBuilder.DropTable(
                name: "actor");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "film");
        }
    }
}
