using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemBeauty.Models;

namespace SystemBeauty.ViewModels
{
    public class CarrinhoCompraVM
    {
        public string CarrinhoCompraID { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }
        public decimal Total { get; set; }
        //public CarrinhoCompra CarrinhoCompra { get; set; }
    }
}
