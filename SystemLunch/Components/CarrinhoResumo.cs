using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using SystemBeauty.Models;
using SystemBeauty.Repositories;
using SystemBeauty.Repositories.Interfaces;
using SystemBeauty.Services.Interfaces;
using SystemBeauty.ViewModels;

namespace SystemBeauty.Components
{
    public class CarrinhoResumo : ViewComponent
    {
        private readonly CarrinhoCompra _carrinho;
        private readonly ICarrinhoCompraService _carrinhoCompra;

        public CarrinhoResumo(ICarrinhoCompraService carrinhoCompra, CarrinhoCompra carrinho)
        {
            _carrinhoCompra = carrinhoCompra;
            _carrinho = carrinho;
        }

        public IViewComponentResult Invoke()
        {
            var IDCarrinho = _carrinho.CarrinhoCompraID;
            var produtos = _carrinhoCompra.GetCarrinhoCompraItens(IDCarrinho);
            var CarrinhoCompraVM = new CarrinhoCompraVM()
            {
                CarrinhoCompraID = IDCarrinho,
                CarrinhoCompraItens = produtos,
                Total = _carrinhoCompra.GetTotal(IDCarrinho)
            };
            return View (CarrinhoCompraVM);
        }
    }
}
