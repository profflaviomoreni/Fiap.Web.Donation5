using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Web.Donation5.Migrations
{
    /// <inheritdoc />
    public partial class Categoria_Index_Nome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Categoria_NomeCategoria",
                table: "Categoria",
                column: "NomeCategoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Categoria_NomeCategoria",
                table: "Categoria");
        }
    }
}
