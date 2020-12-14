using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemBeauty.Migrations
{
    public partial class _Atualizacao_Pedido_Endereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Enderedo1",
                table: "Pedidos",
                newName: "Endereco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Endereco",
                table: "Pedidos",
                newName: "Enderedo1");
        }
    }
}
