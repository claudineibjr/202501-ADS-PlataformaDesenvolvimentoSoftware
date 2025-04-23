using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp8.Migrations
{
    /// <inheritdoc />
    public partial class NewProfissaoFieldOnPessoaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Profissao",
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
                name: "Profissao",
                table: "Pessoas");
        }
    }
}
