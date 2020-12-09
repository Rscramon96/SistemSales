using System.Collections.Generic;
using SystemBeauty.Models;
using SystemBeauty.Repositories.Interfaces;
using SystemBeauty.Services.Interfaces;

namespace SystemBeauty.Services
{
    public class CarrinhoCompraServices : ICarrinhoCompraService
    {
        private readonly ICarrinhoCompraItemRP _carrinhoCompraItem;
        public CarrinhoCompraServices(ICarrinhoCompraItemRP carrinhoCompraItem)
        {
            _carrinhoCompraItem = carrinhoCompraItem;
        }

        public CarrinhoCompra GetCarrinho(CarrinhoCompra CarrinhoCompra)
        {
            CarrinhoCompra cc = CarrinhoCompra;

            var produtos = GetCarrinhoCompraItens(cc.CarrinhoCompraID);
            cc.CarrinhoCompraItens = produtos;
            cc.Total = GetTotal(cc.CarrinhoCompraID);
            return (cc);
        }

        public CarrinhoCompraItem Adicionar(Produto produto, string CarrinhoCompraID)
        {
            var carrinhoCompraItem = _carrinhoCompraItem.FindItem(produto, CarrinhoCompraID);

            if (carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoItemID = CarrinhoCompraID,
                    Produto = produto,
                    Quantidade = 1
                };
                _carrinhoCompraItem.AddCarrinhoCompraItem(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
                _carrinhoCompraItem.UpdateCarrinhoItem(carrinhoCompraItem);
            }
            return carrinhoCompraItem;
        }

        public int Remover(Produto produto, string CarrinhoCompraID)
        {
            var carrinhoCompraItem = _carrinhoCompraItem.FindItem(produto, CarrinhoCompraID);

            if (carrinhoCompraItem != null)
            {
                if (carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                    _carrinhoCompraItem.UpdateCarrinhoItem(carrinhoCompraItem);
                }
                else
                {
                    _carrinhoCompraItem.RemoveItem(carrinhoCompraItem);
                }
            }
            return carrinhoCompraItem.Quantidade;
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItens(string CarrinhoCompraID)
        {
            List<CarrinhoCompraItem> CarrinhoCompraItens = new List<CarrinhoCompraItem>();
            return CarrinhoCompraItens = _carrinhoCompraItem.ListItens(CarrinhoCompraID);
        }
        public string Limpar(string CarrinhoCompraID)
        {
            var carrinhoItens = _carrinhoCompraItem.ListItens(CarrinhoCompraID);
            _carrinhoCompraItem.RemoveAllItens(carrinhoItens);
            return CarrinhoCompraID;
        }

        public decimal GetTotal(string CarrinhoCompraID)
        {
            var Total = _carrinhoCompraItem.GetTotal(CarrinhoCompraID);
            return Total;
        }
    }
}
