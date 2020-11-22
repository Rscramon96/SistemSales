using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SystemBeauty.Models;
using SystemBeauty.Repositories;
using SystemBeauty.ViewModels;

namespace SystemBeauty.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository)
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
    }
}
