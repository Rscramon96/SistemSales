using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemBeauty.Migrations
{
    public partial class AtualizacaoItensPedidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "ItensPedidos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "ItensPedidos");
        }
    }
}
