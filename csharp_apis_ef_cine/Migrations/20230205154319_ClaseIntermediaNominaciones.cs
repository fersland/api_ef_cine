using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharpapisefcine.Migrations
{
    /// <inheritdoc />
    public partial class ClaseIntermediaNominaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NominacionPelicula",
                columns: table => new
                {
                    NominacionesId = table.Column<int>(type: "int", nullable: false),
                    PeliculasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NominacionPelicula", x => new { x.NominacionesId, x.PeliculasId });
                    table.ForeignKey(
                        name: "FK_NominacionPelicula_Nominaciones_NominacionesId",
                        column: x => x.NominacionesId,
                        principalTable: "Nominaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NominacionPelicula_Peliculas_PeliculasId",
                        column: x => x.PeliculasId,
                        principalTable: "Peliculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NominacionPelicula_PeliculasId",
                table: "NominacionPelicula",
                column: "PeliculasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NominacionPelicula");
        }
    }
}
