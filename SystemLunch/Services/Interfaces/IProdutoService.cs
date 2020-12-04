using System.Collections.Generic;
using SystemBeauty.Models;
using SystemBeauty.ViewModels;

namespace SystemBeauty.Services.Interfaces
{
    public interface IProdutoService
    {
        IEnumerable<Categoria> ListaCategorias();
        IEnumerable<Produto> ListaProduto();
        IEnumerable<Produto> ProdutoPorCategoria(int ID);
        IEnumerable<Produto> ListaMaisVendidos();
        Produto AddProduto(Produto produto);
        Produto UpdateProduto(Produto produto);    
        Produto GetProdutoById(int ID);
        ProdutoVM Produto_To_ProdutoVM(Produto produto);
        Produto ProdutoVM_To_Produto(ProdutoVM produto);
    }
}
