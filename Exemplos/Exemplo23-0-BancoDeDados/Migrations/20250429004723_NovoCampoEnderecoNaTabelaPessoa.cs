using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exemplo230BancoDeDados.Migrations
{
    /// <inheritdoc />
    public partial class NovoCampoEnderecoNaTabelaPessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Pessoas",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Pessoas");
        }
    }
}
