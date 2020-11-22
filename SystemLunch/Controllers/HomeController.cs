using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SystemBeauty.Models;
using SystemBeauty.Repositories;
using SystemBeauty.ViewModels;

namespace SystemBeauty.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public HomeController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public IActionResult Index()
        {            
            var produtos= _produtoRepository.ListMaisVendidos;

            List<ProdutoVM> lista = new List<ProdutoVM>();
            foreach (var item in produtos)
            {
                ProdutoVM produtoVM = new ProdutoVM();
                produtoVM.ID = item.ID;
                produtoVM.Nome = item.Nome;
                produtoVM.DescricaoCurta = item.DescricaoCurta;
                produtoVM.VolumeEmbalagem = item.VolumeEmbalagem;
                produtoVM.Preco = item.Preco;
                produtoVM.ImageURL = item.ImageURL;
                produtoVM.QtdEstoque = item.QtdEstoque;
                produtoVM.QtdVendido = item.QtdVendido;

                lista.Add(produtoVM);
            }
            return View(lista);
        }
    }
}
