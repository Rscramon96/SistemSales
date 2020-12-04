using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using SystemBeauty.Models;
using SystemBeauty.Services.Interfaces;
using SystemBeauty.ViewModels;

namespace SystemBeauty.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaService categoriaService, IMapper mapper)
        {
            _categoriaService = categoriaService;
            _mapper = mapper;
        }

        public IActionResult Lista()
        {
            var categoria = _categoriaService.ListaCategorias();
            List<CategoriaVM> lista = new List<CategoriaVM>();
            lista = _mapper.Map<List<CategoriaVM>>(categoria);
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
                var categoria = _mapper.Map<Categoria>(categoriaVM);
                categoria.DataCadastro = DateTime.Now;
                _categoriaService.AddCategoria(categoria);
                return RedirectToAction(nameof(Lista));
            }
            return View(categoriaVM);
        }

        public IActionResult Editar(int id)
        {
            var categoria = _categoriaService.GetCategoriaByID(id);

            if (categoria == null)
            {
                return NotFound();
            }

            try
            {
                var categoriaVM = _mapper.Map<CategoriaVM>(categoria);
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
                var categoria = _categoriaService.GetCategoriaByID(categoriaVM.ID);

                try
                {
                    _categoriaService.UpdateCategoria(categoria);
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
            var categoria = _categoriaService.GetCategoriaByID(id);

            if (categoria == null)
            {
                return NotFound();
            }

            try 
            {
                var categoriaVM = _mapper.Map<CategoriaVM>(categoria);
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
            var categoria = _categoriaService.GetCategoriaByID(Convert.ToInt32(id));

            if (categoria.ID == id)
            {
                categoria.DataExclusao = DateTime.Now;
                categoria.Excluir = true;
                _categoriaService.UpdateCategoria(categoria);
            }
            else
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Lista));
        }
    }
}
