using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemBeauty.Models;
using SystemBeauty.Repositories.Interfaces;
using SystemBeauty.Services.Interfaces;

namespace SystemBeauty.Services
{
    public class CategoriaServices : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaServices(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IEnumerable<Categoria> ListaCategorias()
        {
            return _categoriaRepository.ListaCategorias();
        }

        public Categoria AddCategoria(Categoria categoria)
        {
            return _categoriaRepository.AddCategoria(categoria);
        }

        public Categoria GetCategoriaByID(int ID)
        {
            return _categoriaRepository.GetCategoriaByID(ID);
        }

        public Categoria UpdateCategoria(Categoria categoria)
        {
            return _categoriaRepository.UpdateCategoria(categoria);
        }
    }
}
