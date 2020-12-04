using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using SystemBeauty.Data;

namespace SystemBeauty.Models
{
    public class CarrinhoCompra
    {
        private readonly SBContext _context;

        public CarrinhoCompra(SBContext context)
        {
            _context = context;
        }

        public string CarrinhoCompraID { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }
        public decimal Total { get; set; }

        //BUSCA UM CARRINHO EXISTENTE OU CRIA UM NOVO
        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
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
        #region
        //public void AdicionarAoCarrinho(Produto produto, int qtd)
        //{
        //    var carrinhoCompraItem = _carrinhoCompraItem.FindItem(produto,CarrinhoCompraID);

        //    if (carrinhoCompraItem == null)
        //    {
        //        carrinhoCompraItem = new CarrinhoCompraItem
        //        {
        //            CarrinhoItemID = CarrinhoCompraID,
        //            Produto = produto,
        //            Quantidade = 1
        //        };
        //        _carrinhoCompraItem.AddCarrinhoCompraItem(carrinhoCompraItem);
        //    }
        //    else
        //    {
        //        carrinhoCompraItem.Quantidade++;
        //    }
        //}

        //public int RemoverDoCarrinho(Produto produto)
        //{
        //    var carrinhoCompraItem = _carrinhoCompraItem.FindItem(produto, CarrinhoCompraID);

        //    var quantidadeLocal = 0;

        //    if (carrinhoCompraItem != null)
        //    {
        //        if (carrinhoCompraItem.Quantidade > 1)
        //        {
        //            carrinhoCompraItem.Quantidade--;
        //            quantidadeLocal = carrinhoCompraItem.Quantidade;
        //        }
        //        else
        //        {
        //            _carrinhoCompraItem.RemoveItem(carrinhoCompraItem);
        //        }
        //    }
        //    return quantidadeLocal;
        //}
        //public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
        //{
        //    return CarrinhoCompraItens ?? (CarrinhoCompraItens = _carrinhoCompraItem.ListItens(CarrinhoCompraID));
        //}

        //public void LimparCarrinho()
        //{
        //    var carrinhoItens = _carrinhoCompraItem.ListItens(CarrinhoCompraID);
        //    _carrinhoCompraItem.RemoveAllItens(carrinhoItens);
        //}

        //public decimal GetCarrinhoCompraTotal()
        //{ 
        //    Total = _carrinhoCompraItem.GetTotal(CarrinhoCompraID);
        //    return Total;
        //}
        #endregion
    }
}
