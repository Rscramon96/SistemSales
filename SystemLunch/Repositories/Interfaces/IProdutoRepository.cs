using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemBeauty.Models;

namespace SystemBeauty.Repositories
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
