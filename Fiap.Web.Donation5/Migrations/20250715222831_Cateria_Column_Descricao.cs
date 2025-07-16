using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Web.Donation5.Migrations
{
    /// <inheritdoc />
    public partial class Cateria_Column_Descricao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Categoria",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Categoria");
        }
    }
}
