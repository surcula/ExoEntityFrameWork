using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExoEntityFrameWork.Migrations
{
    /// <inheritdoc />
    public partial class exoEFCore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(100)", nullable: false),
                    AnneeSortie = table.Column<string>(type: "varchar(100)", nullable: false),
                    Acteur = table.Column<string>(type: "varchar(100)", nullable: false),
                    Genre = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_films", x => x.Id);
                    table.CheckConstraint("CK_AnneeSortie", "AnneeSortie > 1975");
                });

            migrationBuilder.CreateIndex(
                name: "IX_films_Title",
                table: "films",
                column: "Title",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "films");
        }
    }
}
