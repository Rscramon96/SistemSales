using System;
using System.Collections.Generic;
using SystemBeauty.Models;
using SystemBeauty.Repositories.Interfaces;
using SystemBeauty.Services.Interfaces;

namespace SystemBeauty.Services
{
    public class CarrinhoCompraServices : ICarrinhoCompraService
    {
        private readonly ICarrinhoCompraItemRP _carrinhoCompraItem;
        private readonly CarrinhoCompra _carrinho;

        public CarrinhoCompraServices(ICarrinhoCompraItemRP carrinhoCompraItem, CarrinhoCompra carrinho)
        {
            _carrinhoCompraItem = carrinhoCompraItem;
            _carrinho = carrinho;
        }

        public string GetCarrinhoByID()
        {
            return _carrinho.CarrinhoCompraID;
        }

        public CarrinhoCompra GetCarrinho(string CarrinhoCompraID)
        {
            CarrinhoCompra carrinho = _carrinho;
            if (CarrinhoCompraID == _carrinho.CarrinhoCompraID)
            {
                List<CarrinhoCompraItem> produtos = GetCarrinhoCompraItens(CarrinhoCompraID);
                carrinho.CarrinhoCompraID = CarrinhoCompraID;
                carrinho.CarrinhoCompraItens = produtos;
                carrinho.Total = GetTotal(CarrinhoCompraID);
            }
            return (carrinho);
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
            //List<CarrinhoCompraItem> CarrinhoCompraItens = new List<CarrinhoCompraItem>();
            return _carrinhoCompraItem.ListItens(CarrinhoCompraID);
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
