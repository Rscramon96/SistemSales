using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemBeauty.Models;

namespace SystemBeauty.Services.Interfaces
{
    public interface IPedidoService
    {
        void CriarPedido(Pedido pedido);
    }
}
