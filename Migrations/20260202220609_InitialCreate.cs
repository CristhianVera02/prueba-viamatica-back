using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prueba_viamatica.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pelicula",
                columns: table => new
                {
                    IdPelicula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duracion = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pelicula", x => x.IdPelicula);
                });

            migrationBuilder.CreateTable(
                name: "sala_cine",
                columns: table => new
                {
                    IdSala = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sala_cine", x => x.IdSala);
                });

            migrationBuilder.CreateTable(
                name: "pelicula_salacine",
                columns: table => new
                {
                    IdPeliculaSala = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPelicula = table.Column<int>(type: "int", nullable: false),
                    IdSalaCine = table.Column<int>(type: "int", nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pelicula_salacine", x => x.IdPeliculaSala);
                    table.ForeignKey(
                        name: "FK_pelicula_salacine_pelicula_IdPelicula",
                        column: x => x.IdPelicula,
                        principalTable: "pelicula",
                        principalColumn: "IdPelicula",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pelicula_salacine_sala_cine_IdSalaCine",
                        column: x => x.IdSalaCine,
                        principalTable: "sala_cine",
                        principalColumn: "IdSala",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pelicula_salacine_IdPelicula",
                table: "pelicula_salacine",
                column: "IdPelicula");

            migrationBuilder.CreateIndex(
                name: "IX_pelicula_salacine_IdSalaCine",
                table: "pelicula_salacine",
                column: "IdSalaCine");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pelicula_salacine");

            migrationBuilder.DropTable(
                name: "pelicula");

            migrationBuilder.DropTable(
                name: "sala_cine");
        }
    }
}
