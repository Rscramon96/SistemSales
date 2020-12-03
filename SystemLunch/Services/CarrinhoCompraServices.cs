using System.Collections.Generic;
using SystemBeauty.Models;
using SystemBeauty.Repositories.Interfaces;
using SystemBeauty.Services.Interfaces;

namespace SystemBeauty.Services
{
    public class CarrinhoCompraServices : ICarrinhoCompraService
    {
        private readonly ICarrinhoCompraItemRepository _carrinhoCompraItem;
        public CarrinhoCompraServices(ICarrinhoCompraItemRepository carrinhoCompraItem)
        {
            _carrinhoCompraItem = carrinhoCompraItem;
        }

        public CarrinhoCompraItem Adicionar(Produto produto, int qtd, string CarrinhoCompraID)
        {
            var carrinhoCompraItem = _carrinhoCompraItem.FindItem(produto, CarrinhoCompraID);

            if (carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoItemID = CarrinhoCompraID,
                    Produto = produto,
                    Quantidade = qtd
                };
                _carrinhoCompraItem.AddCarrinhoCompraItem(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }
            return carrinhoCompraItem;
        }

        public int Remover(Produto produto, int qtd, string CarrinhoCompraID)
        {
            var carrinhoCompraItem = _carrinhoCompraItem.FindItem(produto, CarrinhoCompraID);

            var quantidadeLocal = 0;

            if (carrinhoCompraItem != null)
            {
                if (carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade = carrinhoCompraItem.Quantidade - qtd;
                    quantidadeLocal = carrinhoCompraItem.Quantidade;
                }
                else
                {
                    _carrinhoCompraItem.RemoveItem(carrinhoCompraItem);
                }
            }
            return quantidadeLocal;
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItens(string CarrinhoCompraID)
        {
            List<CarrinhoCompraItem> CarrinhoCompraItens = new List<CarrinhoCompraItem>();
            return CarrinhoCompraItens ?? (CarrinhoCompraItens = _carrinhoCompraItem.ListItens(CarrinhoCompraID));
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
