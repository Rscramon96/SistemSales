using System.Collections.Generic;
using System.Linq;
using SystemBeauty.Data;
using SystemBeauty.Models;
using SystemBeauty.Repositories.Interfaces;

namespace SystemBeauty.Repositories
{
    public class ProdutoRepositoryRP : IProdutoRepository
    {

        private readonly SBContext _context;
        public ProdutoRepositoryRP(SBContext contexto)
        {
            _context = contexto;
        }

        public IEnumerable<Produto> ListProdutos => _context.Produtos.Where(p => !p.Excluir).ToList();

        public IEnumerable<Produto> ListMaisVendidos => _context.Produtos.OrderByDescending(p => p.QtdVendido).Where(p => !p.Excluir).ToList();

        public Produto AddProduto(Produto produto)
        {
            _context.Add(produto);
            _context.SaveChanges();
            return produto;
        }

        public Produto GetProdutoById(int ID)
        {
            return _context.Produtos.FirstOrDefault(p => p.ID == ID);
        }

        public Produto UpdateProduto(Produto produto)
        {
            _context.Update(produto);
            _context.SaveChanges();
            return produto;
        }
    }
}
