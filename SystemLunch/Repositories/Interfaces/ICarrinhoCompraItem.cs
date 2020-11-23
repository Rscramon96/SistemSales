using System.Collections.Generic;
using SystemBeauty.Models;

namespace SystemBeauty.Repositories.Interfaces
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
