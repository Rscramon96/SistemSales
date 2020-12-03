using System.Collections.Generic;
using SystemBeauty.Models;

namespace SystemBeauty.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> ListaProdutos();
        IEnumerable<Produto> ListaMaisVendidos();
        IEnumerable<Produto> ProdutoPorCategoria(int CategoriaID);
        Produto GetProdutoById(int ID);
        Produto AddProduto(Produto produto);
        Produto UpdateProduto(Produto produto);
    }
}
