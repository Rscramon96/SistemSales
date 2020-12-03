using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemBeauty.Models;

namespace SystemBeauty.Services.Interfaces
{
    public interface ICategoriaService
    {
        IEnumerable<Categoria> ListaCategorias();
        Categoria GetCategoriaByID(int ID);
        Categoria AddCategoria(Categoria categoria);
        Categoria UpdateCategoria(Categoria categoria);
    }
}
