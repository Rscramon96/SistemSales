using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemBeauty.Models;

namespace SystemBeauty.Repositories
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> ListCategorias { get; }
        Categoria GetCategoriaByID(int ID);
        Categoria AddCategoria(Categoria categoria);
        Categoria UpdateCategoria(Categoria categoria);
    }
}
