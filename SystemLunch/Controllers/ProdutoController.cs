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
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoRepository produtoRepository,
            ICategoriaRepository categoriaRepository,
            IProdutoService produtoService)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
            _produtoService = produtoService;
        }
        public IActionResult Index()
        {
            var produtoVM = _produtoService.ListaProduto(_produtoRepository.ListProdutos);
            return View(produtoVM);
        }

        public IActionResult Lista(string categoria)
        {
            var produtoVM = _produtoService.ListaProduto(_produtoRepository.ListProdutos);

            string _categoria = categoria;
            IEnumerable<ProdutoVM> produtos;
            string categoriaatual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                produtos = produtoVM;
                categoria = "Todos os Produtos.";
            }
            else
            {

            }


            return View(produtoVM);
        }

        public IActionResult Detalhes(int id)
        {
            var produto = _produtoRepository.GetProdutoById(id);

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
            ViewData["CategoriaID"] = new SelectList(_categoriaRepository.ListCategorias, "ID", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(ProdutoVM produtoVM)
        {
            if (ModelState.IsValid)
            {
                var produto = _produtoService.ProdutoVM_To_Produto(produtoVM);

                _produtoRepository.AddProduto(produto);
                return RedirectToAction(nameof(Lista));
            }
            ViewData["CategoriaID"] = new SelectList(_categoriaRepository.ListCategorias, "ID", "Nome", produtoVM.CategoriaID);
            return View(produtoVM);
        }

        public IActionResult Editar(int id)
        {
            var produto = _produtoRepository.GetProdutoById(id);

            if (produto == null)
            {
                return NotFound();
            }

            try
            {
                var produtoVM = _produtoService.Produto_To_ProdutoVM(produto);
                ViewData["CategoriaID"] = new SelectList(_categoriaRepository.ListCategorias, "ID", "Nome", produtoVM.CategoriaID = produto.CategoriaID);

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
                var produto = _produtoRepository.GetProdutoById(produtoVM.ID);

                try
                {
                    produto = _produtoService.ProdutoVM_To_Produto(produtoVM);
                    _produtoRepository.UpdateProduto(produto);
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
            ViewData["CategoriaID"] = new SelectList(_categoriaRepository.ListCategorias, "ID", "Nome", produtoVM.CategoriaID);
            return View(produtoVM);
        }

        public IActionResult Excluir(int? id)
        {
            var produto = _produtoRepository.GetProdutoById(Convert.ToInt32(id));

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
            var produto = _produtoRepository.GetProdutoById(id);

            if (produto.ID == id)
            {
                produto = _produtoService.ExcluirProduto(produto);
                _produtoRepository.UpdateProduto(produto);
            }
            else
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Lista));
        }
    }
}
