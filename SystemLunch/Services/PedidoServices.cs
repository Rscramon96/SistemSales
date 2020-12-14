using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemBeauty.Models;
using SystemBeauty.Repositories.Interfaces;
using SystemBeauty.Services.Interfaces;

namespace SystemBeauty.Services
{
    public class PedidoServices : IPedidoService
    {
        private readonly ICarrinhoCompraService _carrinhoCompra;
        private readonly CarrinhoCompra _carrinho;
        private readonly IPedidoRP _pedidoRP;

        public PedidoServices(CarrinhoCompra carrinho, IPedidoRP pedidoRP, ICarrinhoCompraService carrinhoCompra)
        {
            _carrinhoCompra = carrinhoCompra;
            _carrinho = carrinho;
            _pedidoRP = pedidoRP;
        }
        public void CriarPedido(Pedido pedido)
        {

            List<CarrinhoCompraItem> listaitens = _carrinhoCompra.GetCarrinhoCompraItens(pedido.CarrinhoCompraID);
            pedido.PedidoEnviado = DateTime.Now;
            _pedidoRP.CriarPedido(pedido, listaitens);
        }
    }
}
