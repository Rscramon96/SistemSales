using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemBeauty.Data;
using SystemBeauty.Interfaces;
using SystemBeauty.Models;

namespace SystemBeauty.Repositories
{
    public class CarrinhoCompraItemRP : ICarrinhoCompraItem
    {
        private readonly SBContext _context;

        public CarrinhoCompraItemRP(SBContext context)
        {
            _context = context;
        }

        public CarrinhoCompraItem FindItem (Produto produto, string ID)
        {
            var item = _context.CarrinhoCompraItens.SingleOrDefault(p => p.Produto.ID == produto.ID && p.CarrinhoItemID == ID);
            _context.SaveChanges();
            return item;
        }

        public CarrinhoCompraItem AddCarrinhoCompraItem(CarrinhoCompraItem carrinhoCompraItem)
        {
            _context.Add(carrinhoCompraItem);
            _context.SaveChanges();
            return null;
        }

        public CarrinhoCompraItem RemoveItem(CarrinhoCompraItem carrinhoCompraItem)
        {
            _context.Remove(carrinhoCompraItem);
            _context.SaveChanges();
            return null;
        }

        public List<CarrinhoCompraItem> RemoveAllItens(List<CarrinhoCompraItem> carrinho)
        {
            _context.CarrinhoCompraItens.RemoveRange(carrinho);
            _context.SaveChanges();
            return null;
        }

        List<CarrinhoCompraItem> ICarrinhoCompraItem.ListItens(string ID)
        {
            var list = _context.CarrinhoCompraItens.Where(c => c.CarrinhoItemID == ID).Include(p => p.Produto).ToList();
            return list;
        }

        public decimal GetTotal(string ID)
        {
            var total = _context.CarrinhoCompraItens.Where(c => c.CarrinhoItemID == ID).Select(c => c.Produto.Preco * c.Quantidade).Sum();
            return total;
        }
    }
}
