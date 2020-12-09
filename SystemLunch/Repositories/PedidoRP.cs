using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemBeauty.Data;
using SystemBeauty.Models;
using SystemBeauty.Repositories.Interfaces;

namespace SystemBeauty.Repositories
{
    public class PedidoRP : IPedidoRP
    {
        private readonly SBContext _context;
        private readonly CarrinhoCompra _carrinho;

        public PedidoRP(SBContext context, CarrinhoCompra carrinho)
        {
            _context = context;
            _carrinho = carrinho;
        }
        public void CriarPedido(Pedido pedido, List<CarrinhoCompraItem> carrinhoCompraItems)
        {
            _context.Add(pedido);

            foreach (var item in carrinhoCompraItems)
            {
                var itenspedido = new ItensPedido()
                {
                    Quantidade = item.Quantidade,
                    ProdutoID = item.Produto.ID,
                    PedidoID = pedido.ID,
                    Preco = item.Produto.Preco
                };
                _context.Add(itenspedido);
            }
            _context.SaveChanges();
        }
    }
}
