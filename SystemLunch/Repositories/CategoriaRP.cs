using System.Collections.Generic;
using System.Linq;
using SystemBeauty.Data;
using SystemBeauty.Models;
using SystemBeauty.Repositories.Interfaces;

namespace SystemBeauty.Repositories
{
    public class CategoriaRP : ICategoriaRP
    {
        private readonly SBContext _context;
        public CategoriaRP(SBContext contexto)
        {
            _context = contexto;
        }

        IEnumerable<Categoria> ICategoriaRP.ListaCategorias()
        {
            return _context.Categorias.OrderBy(c => c.Nome).Where(c => !c.Excluir).ToList();
        }
        public Categoria AddCategoria(Categoria categoria)
        {
            _context.Add(categoria);
            _context.SaveChanges();
            return categoria;
        }

        public Categoria GetCategoriaByID(int ID)
        {
            return _context.Categorias.FirstOrDefault(c => c.ID == ID);
        }

        public Categoria UpdateCategoria(Categoria categoria)
        {
            _context.Update(categoria);
            _context.SaveChanges();
            return categoria;
        }
    }
}
