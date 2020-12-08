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
        private readonly CarrinhoCompra _carrinho;

        public CarrinhoCompraController(IProdutoService produtoService, ICarrinhoCompraService carrinhoCompra, IMapper mapper, CarrinhoCompra carrinho)
        {
            _produtoService = produtoService;
            _carrinhoCompra = carrinhoCompra;
            _mapper = mapper;
            _carrinho = carrinho;
        }
        public IActionResult Index()
        {
            var carrinho = _carrinhoCompra.GetCarrinho(_carrinho);
            CarrinhoCompraVM cc = _mapper.Map<CarrinhoCompraVM>(carrinho);
            return View (cc);
        }
        public IActionResult AddItemCarrinho (int ID)
        {
            var produtoselecionado = _produtoService.GetProdutoById(ID);
            var CarrinhoCompraID = _carrinho.CarrinhoCompraID;

            if (produtoselecionado != null)
            {
                _carrinhoCompra.Adicionar(produtoselecionado, CarrinhoCompraID);
            }
            return RedirectToAction("Index");
        }
        public IActionResult RemoverItemCarrinho (int ID)
        {
            var produtoselecionado = _produtoService.GetProdutoById(ID);
            var CarrinhoCompraID = _carrinho.CarrinhoCompraID;

            if (produtoselecionado != null)
            {
                _carrinhoCompra.Remover(produtoselecionado, CarrinhoCompraID);
            }
            return RedirectToAction("Index");
        }
    }
}
