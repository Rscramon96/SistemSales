using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemBeauty.Models;

namespace SystemBeauty.Interfaces
{
    public  interface ICarrinhoCompraItem
    {
        CarrinhoCompraItem AddCarrinhoCompraItem (CarrinhoCompraItem carrinhoCompraItem);
        CarrinhoCompraItem FindItem (Produto produto, string ID);
        CarrinhoCompraItem RemoveItem (CarrinhoCompraItem carrinhoCompraItem);
        decimal GetTotal (string ID);
        List<CarrinhoCompraItem> RemoveAllItens (List<CarrinhoCompraItem> carrinho);
        List<CarrinhoCompraItem> ListItens (string ID);
    }
}
