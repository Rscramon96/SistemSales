using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SystemBeauty.Repositories.Interfaces;
using SystemBeauty.Services.Interfaces;
using SystemBeauty.ViewModels;

namespace SystemBeauty.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProdutoService _produtoService;

        public HomeController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        public IActionResult Index()
        {            
            var produtos= _produtoService.ListaMaisVendidos();
            return View(produtos);
        }

        public IActionResult Contato ()
        {
            return View();
        }
    }
}
