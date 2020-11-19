﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemBeauty.Data;
using SystemBeauty.Models;

namespace SystemBeauty.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly SBContext _context;
        public CategoriaRepository(SBContext contexto)
        {
            _context = contexto;
        }
        public IEnumerable<Categoria> ListCategorias => _context.Categorias.Where(c => !c.Excluir).ToList();

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
