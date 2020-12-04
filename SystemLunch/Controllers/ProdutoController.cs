using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using SystemBeauty.Models;
using SystemBeauty.Repositories.Interfaces;
using SystemBeauty.ViewModels;
using SystemBeauty.Services.Interfaces;
using AutoMapper;

namespace SystemBeauty.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoService produtoService, IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }
        public IActionResult Index(Categoria categoria)
        {
            IEnumerable<Produto> produtos = _produtoService.ListaProduto();
            List<ProdutoVM> lista = new List<ProdutoVM>();
            lista = _mapper.Map<List<ProdutoVM>>(produtos);

            if (categoria.ID == 0)
            {
                return View(lista);
            }
            else
            {
                IEnumerable<Produto> produtoCategoria = _produtoService.ProdutoPorCategoria(categoria.ID);
                List<ProdutoVM> listaProdutoCategoria = new List<ProdutoVM>();
                listaProdutoCategoria = _mapper.Map<List<ProdutoVM>>(produtoCategoria);
                return View(listaProdutoCategoria);
            }
        }

        public IActionResult Lista()
        {

            IEnumerable<Produto> produtos = _produtoService.ListaProduto();
            List<ProdutoVM> lista = new List<ProdutoVM>();
            lista = _mapper.Map<List<ProdutoVM>>(produtos);
            return View(lista);
        }

        public IActionResult Detalhes(int id)
        {
            var produto = _produtoService.GetProdutoById(id);
            var produtoVM = _mapper.Map<ProdutoVM>(produto);

            if (produto == null)
            {
                return NotFound();
            }

            try
            {                
                return View(produtoVM);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        public IActionResult Cadastrar()
        {
            ViewData["CategoriaID"] = new SelectList(_produtoService.ListaCategorias(), "ID", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(ProdutoVM produtoVM)
        {
            if (ModelState.IsValid)
            {
                var produto = _mapper.Map<Produto>(produtoVM);

                _produtoService.AddProduto(produto);
                return RedirectToAction(nameof(Lista));
            }
            ViewData["CategoriaID"] = new SelectList(_produtoService.ListaCategorias(), "ID", "Nome", produtoVM.CategoriaID);
            return View(produtoVM);
        }

        public IActionResult Editar(int id)
        {
            var produto = _produtoService.GetProdutoById(id);
            var produtoVM = _mapper.Map<ProdutoVM>(produto);

            if (produto == null)
            {
                return NotFound();
            }

            try
            {
                ViewData["CategoriaID"] = new SelectList(_produtoService.ListaCategorias(), "ID", "Nome", produtoVM.CategoriaID = produto.CategoriaID);
                return View(produtoVM);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(ProdutoVM produtoVM)
        {
            if (ModelState.IsValid)
            {
                var produto = _produtoService.GetProdutoById(produtoVM.ID);
                try
                {
                    _produtoService.UpdateProduto(produto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (produtoVM.ID != produto.ID)
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
            ViewData["CategoriaID"] = new SelectList(_produtoService.ListaCategorias(), "ID", "Nome", produtoVM.CategoriaID);
            return View(produtoVM);
        }

        public IActionResult Excluir(int? id)
        {
            var produto = _produtoService.GetProdutoById(Convert.ToInt32(id));

            if (produto == null)
            {
                return NotFound();
            }

            try
            {
                var produtoVM = _mapper.Map<ProdutoVM>(produto);
                return View(produtoVM);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Excluir(int id)
        {
            var produto = _produtoService.GetProdutoById(id);

            if (produto.ID == id)
            {
                _produtoService.UpdateProduto(produto);
            }
            else
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Lista));
        }
    }
}
