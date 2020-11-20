using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemBeauty.Data;
using SystemBeauty.Interfaces;
using SystemBeauty.Models;
using SystemBeauty.Repositories.Interfaces;

namespace SystemBeauty.Repositories
{
    public class CarrinhoCompraRP : ICarrinhoCompra
    {
        private readonly ICarrinhoCompraItem _carrinhoCompraItem;
        public CarrinhoCompraRP(ICarrinhoCompraItem carrinhoCompraItem)
        {
            _carrinhoCompraItem = carrinhoCompraItem;
        }
        public CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            //DEFINE UMA SESSÃO
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            //OBTÉM UM SERVICO DO TIPO CONTEXT
            var context = services.GetService<SBContext>();
            //BUSCA UM ID DO CARRINHO OU GERA UM NOVO
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();
            //ATRIBUI O ID DO CARRINHO NA SESSÃO
            session.SetString("CarrinhoId", carrinhoId);
            //RETORNA O CARRINHO COM O CONTEXTO E O ID ATRIBUIDO OU OBTIDO
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraID = carrinhoId
            };
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

        public List<CarrinhoCompraItem> GetCarrinhoCompraItens(List<CarrinhoCompraItem> CarrinhoCompraItens,string CarrinhoCompraID)
        {
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
