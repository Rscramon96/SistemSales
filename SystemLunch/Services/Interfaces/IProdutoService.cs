using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemBeauty.Models;
using SystemBeauty.ViewModels;

namespace SystemBeauty.Services.Interfaces
{
    public interface IProdutoService
    {
        IEnumerable<ProdutoVM> ListaProduto (IEnumerable<Produto> produtos);
        ProdutoVM Produto_To_ProdutoVM(Produto produto);
        Produto ProdutoVM_To_Produto(ProdutoVM produto);

        Produto ExcluirProduto(Produto produto);
    }
}
