using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Migrations
{
    /// <inheritdoc />
    public partial class GenreImplementation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GameEntityId = table.Column<int>(type: "int", nullable: true),
                    GenreEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genres_Games_GameEntityId",
                        column: x => x.GameEntityId,
                        principalTable: "Games",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Genres_Genres_GenreEntityId",
                        column: x => x.GenreEntityId,
                        principalTable: "Genres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Genres_GameEntityId",
                table: "Genres",
                column: "GameEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_GenreEntityId",
                table: "Genres",
                column: "GenreEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
