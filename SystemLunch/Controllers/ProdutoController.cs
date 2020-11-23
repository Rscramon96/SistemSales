using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using SystemBeauty.Models;
using SystemBeauty.Repositories.Interfaces;
using SystemBeauty.ViewModels;

namespace SystemBeauty.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        public ProdutoController(IProdutoRepository produtoRepository,
            ICategoriaRepository categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }
        public IActionResult Index()
        {
            var produto = _produtoRepository.ListProdutos;

            List<ProdutoVM> lista = new List<ProdutoVM>();
            foreach (var item in produto)
            {
                ProdutoVM produtoVM = new ProdutoVM();
                produtoVM.ID = item.ID;
                produtoVM.Nome = item.Nome;
                produtoVM.DescricaoCurta = item.DescricaoCurta;
                produtoVM.VolumeEmbalagem = item.VolumeEmbalagem;
                produtoVM.Preco = item.Preco;
                produtoVM.ImageURL = item.ImageURL;
                produtoVM.QtdEstoque = item.QtdEstoque;
                lista.Add(produtoVM);
            }
            return View(lista);
        }

        public IActionResult Lista()
        {
            var produto = _produtoRepository.ListProdutos;
            
            List<ProdutoVM> lista = new List<ProdutoVM>();
            foreach (var item in produto)
            {
                ProdutoVM produtoVM = new ProdutoVM();
                produtoVM.ID = item.ID;
                produtoVM.Nome = item.Nome;
                produtoVM.DescricaoCurta = item.DescricaoCurta;
                produtoVM.VolumeEmbalagem = item.VolumeEmbalagem;
                produtoVM.Preco = item.Preco;
                produtoVM.ImageURL = item.ImageURL;
                produtoVM.QtdEstoque = item.QtdEstoque;
                lista.Add(produtoVM);
            }
            return View(lista);
        }

        public IActionResult Detalhes(int id)
        {
            var produto = _produtoRepository.GetProdutoById(id);
            //var produto = _context.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound();
            }

            try
            {
                var produtoVM = new ProdutoVM();

                produtoVM.ID = produto.ID;
                produtoVM.DataCadastro = produto.DataCadastro;
                produtoVM.Nome = produto.Nome;
                produtoVM.DescricaoCurta = produto.DescricaoCurta;
                produtoVM.DescricaoAdicional = produto.DescricaoAdicional;
                produtoVM.DescricaoProduto = produto.DescricaoProduto;
                produtoVM.ModoUso = produto.ModoUso;
                produtoVM.AcaoBeneficio = produto.AcaoBeneficio;
                produtoVM.VolumeEmbalagem = produto.VolumeEmbalagem;
                produtoVM.Composicao = produto.Composicao;
                produtoVM.Indicacao = produto.Indicacao;
                produtoVM.Preco = produto.Preco;
                produtoVM.ImageURL = produto.ImageURL;
                produtoVM.ImageThumbNailURL = produto.ImageThumbNailURL;
                produtoVM.QtdEstoque = produto.QtdEstoque;
                produtoVM.CategoriaID = produto.CategoriaID;

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
                var produto = new Produto();

                produto.DataCadastro = DateTime.Now;
                produto.Nome = produtoVM.Nome;
                produto.DescricaoCurta = produtoVM.DescricaoCurta;
                produto.DescricaoAdicional = produtoVM.DescricaoAdicional;
                produto.DescricaoProduto = produtoVM.DescricaoProduto;
                produto.ModoUso = produtoVM.ModoUso;
                produto.AcaoBeneficio = produtoVM.AcaoBeneficio;
                produto.VolumeEmbalagem = produtoVM.VolumeEmbalagem;
                produto.Composicao = produtoVM.Composicao;
                produto.Indicacao = produtoVM.Indicacao;
                produto.Preco = produtoVM.Preco;
                produto.ImageURL = produtoVM.ImageURL;
                produto.ImageThumbNailURL = produtoVM.ImageThumbNailURL;
                produto.QtdEstoque = produtoVM.QtdEstoque;
                produto.CategoriaID = produtoVM.CategoriaID;

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
                var produtoVM = new ProdutoVM();

                produtoVM.DataCadastro = produto.DataCadastro;
                produtoVM.Nome = produto.Nome;
                produtoVM.DescricaoCurta = produto.DescricaoCurta;
                produtoVM.DescricaoAdicional = produto.DescricaoAdicional;
                produtoVM.DescricaoProduto = produto.DescricaoProduto;
                produtoVM.ModoUso = produto.ModoUso;
                produtoVM.AcaoBeneficio = produto.AcaoBeneficio;
                produtoVM.VolumeEmbalagem = produto.VolumeEmbalagem;
                produtoVM.Composicao = produto.Composicao;
                produtoVM.Indicacao = produto.Indicacao;
                produtoVM.Preco = produto.Preco;
                produtoVM.ImageURL = produto.ImageURL;
                produtoVM.ImageThumbNailURL = produto.ImageThumbNailURL;
                produtoVM.QtdEstoque = produto.QtdEstoque;                
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
                    produto.Nome = produtoVM.Nome;
                    produto.DescricaoCurta = produtoVM.DescricaoCurta;
                    produto.DescricaoAdicional = produtoVM.DescricaoAdicional;
                    produto.DescricaoProduto = produtoVM.DescricaoProduto;
                    produto.ModoUso = produtoVM.ModoUso;
                    produto.AcaoBeneficio = produtoVM.AcaoBeneficio;
                    produto.VolumeEmbalagem = produtoVM.VolumeEmbalagem;
                    produto.Composicao = produtoVM.Composicao;
                    produto.Indicacao = produtoVM.Indicacao;
                    produto.Preco = produtoVM.Preco;
                    produto.ImageURL = produtoVM.ImageURL;
                    produto.ImageThumbNailURL = produtoVM.ImageThumbNailURL;
                    produto.QtdEstoque = produtoVM.QtdEstoque;
                    produto.CategoriaID = produtoVM.CategoriaID;

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
                var produtoVM = new ProdutoVM();

                produtoVM.DataCadastro = produto.DataCadastro;
                produtoVM.Nome = produto.Nome;
                produtoVM.DescricaoCurta = produto.DescricaoCurta;
                produtoVM.DescricaoAdicional = produto.DescricaoAdicional;
                produtoVM.DescricaoProduto = produto.DescricaoProduto;
                produtoVM.ModoUso = produto.ModoUso;
                produtoVM.AcaoBeneficio = produto.AcaoBeneficio;
                produtoVM.VolumeEmbalagem = produto.VolumeEmbalagem;
                produtoVM.Composicao = produto.Composicao;
                produtoVM.Indicacao = produto.Indicacao;
                produtoVM.Preco = produto.Preco;
                produtoVM.ImageURL = produto.ImageURL;
                produtoVM.ImageThumbNailURL = produto.ImageThumbNailURL;
                produtoVM.QtdEstoque = produto.QtdEstoque;
                produtoVM.CategoriaID = produto.CategoriaID;

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
                var produtoVM = new ProdutoVM();

                produto.DataExclusao = DateTime.Now;
                produto.Excluir = true;
                produto.Nome = produtoVM.Nome;
                produto.DescricaoCurta = produtoVM.DescricaoCurta;
                produto.DescricaoAdicional = produtoVM.DescricaoAdicional;
                produto.DescricaoProduto = produtoVM.DescricaoProduto;
                produto.ModoUso = produtoVM.ModoUso;
                produto.AcaoBeneficio = produtoVM.AcaoBeneficio;
                produto.VolumeEmbalagem = produtoVM.VolumeEmbalagem;
                produto.Composicao = produtoVM.Composicao;
                produto.Indicacao = produtoVM.Indicacao;
                produto.Preco = produtoVM.Preco;
                produto.ImageURL = produtoVM.ImageURL;
                produto.ImageThumbNailURL = produtoVM.ImageThumbNailURL;
                produto.QtdEstoque = produtoVM.QtdEstoque;
                produto.CategoriaID = produtoVM.CategoriaID;

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
