using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcComercio.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCliente = table.Column<string>(maxLength: 20, nullable: false),
                    ApellidoCliente = table.Column<string>(maxLength: 20, nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    CorreoElectronico = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: false),
                    Ciudad = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneroMusical",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genero = table.Column<string>(maxLength: 50, nullable: false),
                    ImagenGenero = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneroMusical", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCompra = table.Column<DateTime>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Factura_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Artista",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 20, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 20, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: true),
                    Nacionalidad = table.Column<string>(maxLength: 30, nullable: false),
                    GeneroMusucalId = table.Column<int>(nullable: false),
                    GeneroMusicalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artista", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artista_GeneroMusical_GeneroMusicalId",
                        column: x => x.GeneroMusicalId,
                        principalTable: "GeneroMusical",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Disco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreDisco = table.Column<string>(nullable: false),
                    FechaPublicacion = table.Column<DateTime>(nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ImagenPortada = table.Column<string>(nullable: true),
                    ArtistaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disco_Artista_ArtistaId",
                        column: x => x.ArtistaId,
                        principalTable: "Artista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cancion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(nullable: false),
                    Duracion = table.Column<DateTime>(nullable: true),
                    DiscoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cancion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cancion_Disco_DiscoId",
                        column: x => x.DiscoId,
                        principalTable: "Disco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleFactura",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscoId = table.Column<int>(nullable: false),
                    FacturaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleFactura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleFactura_Disco_DiscoId",
                        column: x => x.DiscoId,
                        principalTable: "Disco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleFactura_Factura_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "Factura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artista_GeneroMusicalId",
                table: "Artista",
                column: "GeneroMusicalId");

            migrationBuilder.CreateIndex(
                name: "IX_Cancion_DiscoId",
                table: "Cancion",
                column: "DiscoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFactura_DiscoId",
                table: "DetalleFactura",
                column: "DiscoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFactura_FacturaId",
                table: "DetalleFactura",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disco_ArtistaId",
                table: "Disco",
                column: "ArtistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_ClienteId",
                table: "Factura",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cancion");

            migrationBuilder.DropTable(
                name: "DetalleFactura");

            migrationBuilder.DropTable(
                name: "Disco");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Artista");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "GeneroMusical");
        }
    }
}
