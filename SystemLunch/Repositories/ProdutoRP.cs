using System.Collections.Generic;
using System.Linq;
using SystemBeauty.Data;
using SystemBeauty.Models;
using SystemBeauty.Repositories.Interfaces;

namespace SystemBeauty.Repositories
{
    public class ProdutoRP : IProdutoRP
    {

        private readonly SBContext _context;
        public ProdutoRP(SBContext contexto)
        {
            _context = contexto;
        }

        IEnumerable<Produto> IProdutoRP.ListaProdutos()
        {
            return _context.Produtos.OrderBy(p => p.ID).Where(p => !p.Excluir).ToList();
        }

        IEnumerable<Produto> IProdutoRP.ListaMaisVendidos()
        {
            return _context.Produtos.OrderByDescending(p => p.QtdVendido).Where(p => !p.Excluir).ToList();
        }

        public IEnumerable<Produto> ProdutoPorCategoria(int CategoriaID)
        {
            return _context.Produtos.OrderBy(p => p.ID).Where(p => p.CategoriaID == CategoriaID).ToList();
        }

        public IEnumerable<Produto> Busca(string busca)
        {
            return _context.Produtos.Where(p => p.Nome.ToLower().Contains(busca));
        }
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
