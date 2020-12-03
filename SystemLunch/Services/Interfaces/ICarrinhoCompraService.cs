using System;
using System.Collections.Generic;
using SystemBeauty.Models;

namespace SystemBeauty.Services.Interfaces
{
    public interface ICarrinhoCompraService
    {
        //CarrinhoCompra GetCarrinho(IServiceProvider services);
        CarrinhoCompraItem Adicionar(Produto produto, int qtd, string CarrinhoCompraID);
        int Remover(Produto produto, int qtd, string CarrinhoCompraID);
        string Limpar(string CarrinhoCompraID);
        decimal GetTotal(string CarrinhoCompraID);
        List<CarrinhoCompraItem> GetCarrinhoCompraItens(string ID);
    }
}
