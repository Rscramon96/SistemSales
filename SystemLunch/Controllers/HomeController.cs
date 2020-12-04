using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SystemBeauty.Models;
using SystemBeauty.Repositories.Interfaces;
using SystemBeauty.Services.Interfaces;
using SystemBeauty.ViewModels;

namespace SystemBeauty.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public HomeController(IProdutoService produtoService, IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {            
            IEnumerable<Produto> produtos = _produtoService.ListaMaisVendidos();
            List<ProdutoVM> lista = new List<ProdutoVM>();
            lista = _mapper.Map<List<ProdutoVM>>(produtos);
            return View(lista);
        }

        public IActionResult Contato ()
        {
            return View();
        }
    }
}
