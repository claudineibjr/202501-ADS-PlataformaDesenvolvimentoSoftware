using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exemplo230BancoDeDados.Migrations
{
    /// <inheritdoc />
    public partial class NovaTabelaEmprego : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmpregoId",
                table: "Pessoas",
                type: "varchar(255)",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Empregos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Profissao = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Salario = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empregos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_EmpregoId",
                table: "Pessoas",
                column: "EmpregoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Empregos_EmpregoId",
                table: "Pessoas",
                column: "EmpregoId",
                principalTable: "Empregos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Empregos_EmpregoId",
                table: "Pessoas");

            migrationBuilder.DropTable(
                name: "Empregos");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_EmpregoId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "EmpregoId",
                table: "Pessoas");
        }
    }
}
