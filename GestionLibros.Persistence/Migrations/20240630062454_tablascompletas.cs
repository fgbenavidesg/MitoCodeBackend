using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionLibros.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class tablascompletas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Biblioteca");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "Clientes",
                newSchema: "Biblioteca");

            migrationBuilder.AlterColumn<string>(
                name: "Nombres",
                schema: "Biblioteca",
                table: "Clientes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Apellidos",
                schema: "Biblioteca",
                table: "Clientes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                schema: "Biblioteca",
                table: "Clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Libros",
                schema: "Biblioteca",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                schema: "Biblioteca",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaPedido = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    ClienteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LibrosId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalSchema: "Biblioteca",
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Libros_LibrosId",
                        column: x => x.LibrosId,
                        principalSchema: "Biblioteca",
                        principalTable: "Libros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_DNI",
                schema: "Biblioteca",
                table: "Clientes",
                column: "DNI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteId",
                schema: "Biblioteca",
                table: "Pedido",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_LibrosId",
                schema: "Biblioteca",
                table: "Pedido",
                column: "LibrosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedido",
                schema: "Biblioteca");

            migrationBuilder.DropTable(
                name: "Libros",
                schema: "Biblioteca");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_DNI",
                schema: "Biblioteca",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Biblioteca",
                table: "Clientes");

            migrationBuilder.RenameTable(
                name: "Clientes",
                schema: "Biblioteca",
                newName: "Clientes");

            migrationBuilder.AlterColumn<string>(
                name: "Nombres",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Apellidos",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);
        }
    }
}
