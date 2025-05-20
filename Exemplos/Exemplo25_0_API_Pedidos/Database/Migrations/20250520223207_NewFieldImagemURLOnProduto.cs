using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exemplo25_0_API_Pedidos.Migrations
{
    /// <inheritdoc />
    public partial class NewFieldImagemURLOnProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagemURL",
                table: "Produtos",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemURL",
                table: "Produtos");
        }
    }
}
