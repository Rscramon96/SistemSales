using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemBeauty.Models;

namespace SystemBeauty.Repositories.Interfaces
{
    public interface IPedidoRP
    {
        void CriarPedido(Pedido Pedido, List<CarrinhoCompraItem> carrinhoCompraItems);
    }
}
