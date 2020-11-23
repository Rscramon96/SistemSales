using System.Collections.Generic;
using SystemBeauty.Models;

namespace SystemBeauty.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> ListProdutos { get; }
        IEnumerable<Produto> ListMaisVendidos { get; }
        Produto GetProdutoById(int ID);
        Produto AddProduto(Produto produto);
        Produto UpdateProduto(Produto produto);
    }
}
