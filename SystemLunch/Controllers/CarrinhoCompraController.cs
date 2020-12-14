using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SystemBeauty.Models;
using SystemBeauty.Services.Interfaces;
using SystemBeauty.ViewModels;

namespace SystemBeauty.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly ICarrinhoCompraService _carrinhoCompra;
        private readonly IMapper _mapper;

        public CarrinhoCompraController(IProdutoService produtoService, ICarrinhoCompraService carrinhoCompra, IMapper mapper)
        {
            _produtoService = produtoService;
            _carrinhoCompra = carrinhoCompra;
            _mapper = mapper;
        }
        public IActionResult Index(string CarrinhoCompraID)
        {
            var carrinho = _carrinhoCompra.GetCarrinho(CarrinhoCompraID);
            if (carrinho != null)
            {
                CarrinhoCompraVM carrinhoVM = _mapper.Map<CarrinhoCompraVM>(carrinho);
                return View(carrinhoVM);
            }
            else
            {
                return NotFound();
            }
        }
        public IActionResult AddItemCarrinho(int ID)
        {
            var produtoselecionado = _produtoService.GetProdutoById(ID);
            var CarrinhoCompraID = _carrinhoCompra.GetCarrinhoByID();

            if (produtoselecionado != null)
            {
                _carrinhoCompra.Adicionar(produtoselecionado, CarrinhoCompraID);
                return RedirectToAction("Index", new { CarrinhoCompraID = CarrinhoCompraID} );
            }
            else
            {
                return NotFound();
            }
        }
        public IActionResult RemoverItemCarrinho(int ID)
        {
            var produtoselecionado = _produtoService.GetProdutoById(ID);
            var CarrinhoCompraID = _carrinhoCompra.GetCarrinhoByID();

            if (produtoselecionado != null)
            {
                _carrinhoCompra.Remover(produtoselecionado, CarrinhoCompraID);
                return RedirectToAction("Index", new { CarrinhoCompraID = CarrinhoCompraID });
            }
            else
            {
                return NotFound();
            }
        }
    }
}
