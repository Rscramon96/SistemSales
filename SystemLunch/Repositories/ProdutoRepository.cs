using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemBeauty.Data;
using SystemBeauty.Models;

namespace SystemBeauty.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly SBContext _context;
        public ProdutoRepository(SBContext contexto)
        {
            _context = contexto;
        }

        public IEnumerable<Produto> ListProdutos => _context.Produtos.Where(p => !p.Excluir).ToList();

        public IEnumerable<Produto> ListProdutosPreferidos => _context.Produtos.Where(p => p.ProdutoPreferido && !p.Excluir)
            .Include(c => !c.Categoria.Excluir);

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
