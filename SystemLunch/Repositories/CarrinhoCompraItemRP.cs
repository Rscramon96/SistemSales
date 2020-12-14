using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using SystemBeauty.Data;
using SystemBeauty.Models;
using SystemBeauty.Repositories.Interfaces;

namespace SystemBeauty.Repositories
{
    public class CarrinhoCompraItemRP : ICarrinhoCompraItemRP
    {
        private readonly SBContext _context;

        public CarrinhoCompraItemRP(SBContext context)
        {
            _context = context;
        }

        public CarrinhoCompraItem FindItem (Produto produto, string ID)
        {
            var item = _context.CarrinhoCompraItens.SingleOrDefault(p => p.Produto.ID == produto.ID && p.CarrinhoItemID == ID);
            return item;
        }

        public CarrinhoCompraItem AddCarrinhoCompraItem(CarrinhoCompraItem carrinhoCompraItem)
        {
            _context.Add(carrinhoCompraItem);
            _context.SaveChanges();
            return carrinhoCompraItem;
        }
        public CarrinhoCompraItem UpdateCarrinhoItem(CarrinhoCompraItem carrinhoCompraItem)
        {
            _context.Update(carrinhoCompraItem);
            _context.SaveChanges();
            return carrinhoCompraItem;
        }

        public CarrinhoCompraItem RemoveItem(CarrinhoCompraItem carrinhoCompraItem)
        {
            _context.Remove(carrinhoCompraItem);
            _context.SaveChanges();
            return carrinhoCompraItem;
        }

        public List<CarrinhoCompraItem> RemoveAllItens(List<CarrinhoCompraItem> carrinho)
        {
            _context.CarrinhoCompraItens.RemoveRange(carrinho);
            _context.SaveChanges();
            return carrinho;
        }

        public List<CarrinhoCompraItem> ListItens(string CarrinhoID)
        {
            return _context.CarrinhoCompraItens.Where(c => c.CarrinhoItemID == CarrinhoID).Include(p => p.Produto).ToList();
        }

        public decimal GetTotal(string ID)
        {
            return _context.CarrinhoCompraItens.Where(c => c.CarrinhoItemID == ID).Select(c => c.Produto.Preco * c.Quantidade).Sum();
        }
    }
}
