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
        IEnumerable<Produto> ListaBusca(string search);
        Produto AddProduto(Produto produto);
        Produto UpdateProduto(Produto produto);    
        Produto GetProdutoById(int ID);
    }
}
