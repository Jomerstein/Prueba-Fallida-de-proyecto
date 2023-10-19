using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationPrueba.Migrations
{
    /// <inheritdoc />
    public partial class PrimerMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.idUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Entrada",
                columns: table => new
                {
                    codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    esValida = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioidUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrada", x => x.codigo);
                    table.ForeignKey(
                        name: "FK_Entrada_Usuario_UsuarioidUsuario",
                        column: x => x.UsuarioidUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Espectaculo",
                columns: table => new
                {
                    idEspectaculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    visibilidad = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioidUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Espectaculo", x => x.idEspectaculo);
                    table.ForeignKey(
                        name: "FK_Espectaculo_Usuario_UsuarioidUsuario",
                        column: x => x.UsuarioidUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_UsuarioidUsuario",
                table: "Entrada",
                column: "UsuarioidUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Espectaculo_UsuarioidUsuario",
                table: "Espectaculo",
                column: "UsuarioidUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entrada");

            migrationBuilder.DropTable(
                name: "Espectaculo");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
