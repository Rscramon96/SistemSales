using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SystemBeauty.Models;
using SystemBeauty.Services.Interfaces;
using SystemBeauty.ViewModels;

namespace SystemBeauty.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoService _pedidoService;
        private readonly ICarrinhoCompraService _carrinhoCompra;
        private readonly IMapper _mapper;

        public PedidoController(IPedidoService pedidoService, ICarrinhoCompraService carrinhoCompra, IMapper mapper)
        {
            _pedidoService = pedidoService;
            _carrinhoCompra = carrinhoCompra;
            _mapper = mapper;
        }
        public IActionResult Checkout(string CarrinhoCompraID)
        {
            var carrinho = _carrinhoCompra.GetCarrinho(CarrinhoCompraID);
            PedidoVM pedido = new PedidoVM();
            pedido.CarrinhoCompra = carrinho;
            return View(pedido);
        }

        [HttpPost]
        public IActionResult Checkout(PedidoVM pedidoVM)
        {
            //var CarrinhoCompraID = _carrinhoCompra.GetCarrinhoByID(); 
            var itens = _carrinhoCompra.GetCarrinhoCompraItens(pedidoVM.CarrinhoCompraID);
            var carrinho = _carrinhoCompra.GetCarrinho(pedidoVM.CarrinhoCompraID);

            carrinho.CarrinhoCompraItens = itens;
            if (ModelState.IsValid)
            {
                var pedido = _mapper.Map<Pedido>(pedidoVM);
                _pedidoService.CriarPedido(pedido);
                _carrinhoCompra.Limpar(pedidoVM.CarrinhoCompraID);
                return RedirectToAction("CheckoutCompleto");
            }
            else
            {
                //ModelState.AddModelError("", "Seu carrinho está vazio, inclua um produto para concluir seu pedido!");
                pedidoVM.CarrinhoCompra = carrinho;
                return View (pedidoVM);
            }
        }
        public IActionResult CheckoutCompleto()
        {
            ViewBag.Mensagem = "Pedido concluído com sucesso! Obrigado!";
            return View();
        }
    }
}
