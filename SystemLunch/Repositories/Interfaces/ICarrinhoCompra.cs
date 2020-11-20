using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemBeauty.Models;

namespace SystemBeauty.Repositories.Interfaces
{
    public interface ICarrinhoCompra
    {
        CarrinhoCompra GetCarrinho(IServiceProvider services); 
        CarrinhoCompraItem Adicionar(Produto produto, int qtd, string CarrinhoCompraID);
        int Remover(Produto produto, int qtd, string CarrinhoCompraID);
        string Limpar(string CarrinhoCompraID);
        decimal GetTotal(string CarrinhoCompraID);
        List<CarrinhoCompraItem> GetCarrinhoCompraItens(List<CarrinhoCompraItem> CarrinhoCompraItens, string ID);
    }
}
