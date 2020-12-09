using System.Collections.Generic;
using SystemBeauty.Models;

namespace SystemBeauty.Repositories.Interfaces
{
    public interface IProdutoRP
    {
        IEnumerable<Produto> ListaProdutos();
        IEnumerable<Produto> ListaMaisVendidos();
        IEnumerable<Produto> ProdutoPorCategoria(int CategoriaID);
        IEnumerable<Produto> Busca(string search);
        Produto GetProdutoById(int ID);
        Produto AddProduto(Produto produto);
        Produto UpdateProduto(Produto produto);
    }
}
