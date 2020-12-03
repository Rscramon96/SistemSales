using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using SystemBeauty.Models;
using SystemBeauty.Repositories.Interfaces;
using SystemBeauty.ViewModels;
using SystemBeauty.Services.Interfaces;

namespace SystemBeauty.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        public IActionResult Index()
        {
            var produtoVM = _produtoService.ListaProduto();
            return View(produtoVM);
        }

        public IActionResult Lista(Categoria categoria)
        {
            var produtoVM = _produtoService.ListaProduto();

            if (categoria.ID == null)
            {
                return View(produtoVM);
            }
            else
            {
                var produtoCategoria = _produtoService.ProdutoPorCategoria(categoria.ID);
                return View(produtoCategoria);
            }
        }

        public IActionResult Detalhes(int id)
        {
            var produto = _produtoService.GetProdutoById(id);

            if (produto == null)
            {
                return NotFound();
            }

            try
            {
                var produtoVM = _produtoService.Produto_To_ProdutoVM(produto);
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
                var produto = _produtoService.ProdutoVM_To_Produto(produtoVM);

                _produtoService.AddProduto(produto);
                return RedirectToAction(nameof(Lista));
            }
            ViewData["CategoriaID"] = new SelectList(_produtoService.ListaCategorias(), "ID", "Nome", produtoVM.CategoriaID);
            return View(produtoVM);
        }

        public IActionResult Editar(int id)
        {
            var produto = _produtoService.GetProdutoById(id);

            if (produto == null)
            {
                return NotFound();
            }

            try
            {
                var produtoVM = _produtoService.Produto_To_ProdutoVM(produto);
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
                    produto = _produtoService.ProdutoVM_To_Produto(produtoVM);
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
                var produtoVM = _produtoService.Produto_To_ProdutoVM(produto);
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
