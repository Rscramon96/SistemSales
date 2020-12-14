using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemBeauty.Migrations
{
    public partial class Inclusao_Classe_Pedido_CarrinhoCompraID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarrinhoCompraID",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarrinhoCompraID",
                table: "Pedidos");
        }
    }
}
