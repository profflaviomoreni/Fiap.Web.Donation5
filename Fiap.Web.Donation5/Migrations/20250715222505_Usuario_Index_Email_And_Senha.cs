using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Web.Donation5.Migrations
{
    /// <inheritdoc />
    public partial class Usuario_Index_Email_And_Senha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email_Senha",
                table: "Usuario",
                columns: new[] { "Email", "Senha" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuario_Email_Senha",
                table: "Usuario");
        }
    }
}
