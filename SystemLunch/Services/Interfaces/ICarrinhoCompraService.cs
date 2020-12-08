using System.Collections.Generic;
using SystemBeauty.Models;

namespace SystemBeauty.Services.Interfaces
{
    public interface ICarrinhoCompraService
    {
        CarrinhoCompra GetCarrinho(CarrinhoCompra CarrinhoCompra);
        CarrinhoCompraItem Adicionar(Produto produto, string CarrinhoCompraID);
        int Remover(Produto produto, string CarrinhoCompraID);
        string Limpar(string CarrinhoCompraID);
        decimal GetTotal(string CarrinhoCompraID);
        List<CarrinhoCompraItem> GetCarrinhoCompraItens(string ID);
    }
}
