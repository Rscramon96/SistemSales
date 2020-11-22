using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemBeauty.Migrations
{
    public partial class ProdutosQtdVendidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProdutoPreferido",
                table: "Produtos");

            migrationBuilder.AddColumn<int>(
                name: "QtdVendido",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QtdVendido",
                table: "Produtos");

            migrationBuilder.AddColumn<bool>(
                name: "ProdutoPreferido",
                table: "Produtos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
