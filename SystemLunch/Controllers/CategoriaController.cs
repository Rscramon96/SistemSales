using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SystemBeauty.Data;
using SystemBeauty.Models;
using SystemBeauty.Repositories;
using SystemBeauty.ViewModels;

namespace SystemBeauty.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult Lista()
        {
            var categoria = _categoriaRepository.ListCategorias;
            //var categoria = _context.Categorias.Where(x => !x.Excluir).ToList();
            List<CategoriaVM> lista = new List<CategoriaVM>();

            foreach (var item in categoria)
            {
                CategoriaVM categoriaVM = new CategoriaVM();
                categoriaVM.ID = item.ID;
                categoriaVM.Nome = item.Nome;
                categoriaVM.Descricao = item.Descricao;
                categoriaVM.DataCadastro = item.DataCadastro;
                lista.Add(categoriaVM);
            }
            return View(lista);
        }
       
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(CategoriaVM categoriaVM)
        {
            if (ModelState.IsValid)
            {
                var categoria = new Categoria();

                categoria.ID = categoriaVM.ID;
                categoria.Nome = categoriaVM.Nome;
                categoria.Descricao = categoriaVM.Descricao;
                categoria.DataCadastro = DateTime.Now;

                //_context.Add(categoria);
                //_context.SaveChanges();
                _categoriaRepository.AddCategoria(categoria);
                return RedirectToAction(nameof(Lista));
            }
            return View(categoriaVM);
        }

        public IActionResult Editar(int id)
        {
            var categoria = _categoriaRepository.GetCategoriaByID(id);
            //var categoria = _context.Categorias.Find(id);
            if (categoria == null)
            {
                return NotFound();
            }

            try
            {
                var categoriaVM = new CategoriaVM();

                categoriaVM.ID = categoria.ID;
                categoriaVM.Nome = categoria.Nome;
                categoriaVM.Descricao = categoria.Descricao;

                return View(categoriaVM);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(CategoriaVM categoriaVM)
        {
            if (ModelState.IsValid)
            {
                var categoria = _categoriaRepository.GetCategoriaByID(categoriaVM.ID);
                //var categoria = _context.Categorias.Find(categoriaVM.ID);
                try
                {
                    categoria.ID = categoriaVM.ID;
                    categoria.Nome = categoriaVM.Nome;
                    categoria.Descricao = categoriaVM.Descricao;
                    categoria.DataCadastro = categoria.DataCadastro;
                    categoria.DataExclusao = categoria.DataExclusao;
                    categoria.Excluir = categoriaVM.Excluir;

                    _categoriaRepository.UpdateCategoria(categoria);
                    //_context.Categorias.Update(categoria);
                    //_context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (categoria.ID != categoriaVM.ID)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Lista));
            }
            return View(categoriaVM);
        }

        public IActionResult Excluir(int id)
        {
            var categoria = _categoriaRepository.GetCategoriaByID(id);
            //var categoria = _context.Categorias.Find(id);

            if (categoria == null)
            {
                return NotFound();
            }

            try 
            {
                var categoriaVM = new CategoriaVM();
                categoriaVM.ID = categoria.ID;
                categoriaVM.Nome = categoria.Nome;
                categoriaVM.Descricao = categoria.Descricao;

                return View(categoriaVM);
            }

            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Excluir(int? id)
        {
            var categoria = _categoriaRepository.GetCategoriaByID(Convert.ToInt32(id));
            //var categoria = _context.Categorias.Find(id);
            if (categoria.ID == id)
            {
                var categoriaVM = new CategoriaVM();

                categoria.Nome = categoriaVM.Nome;
                categoria.Descricao = categoriaVM.Descricao;
                categoria.DataCadastro = categoriaVM.DataCadastro;
                categoria.DataExclusao = DateTime.Now;
                categoria.Excluir = true;

                _categoriaRepository.UpdateCategoria(categoria);
                //_context.Categorias.Update(categoria);
                //_context.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Lista));
        }
    }
}
