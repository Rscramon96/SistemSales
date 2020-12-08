using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemBeauty.Models;

namespace SystemBeauty.ViewModels
{
    public class CarrinhoCompraItemVM
    {
        public int ID { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public string CarrinhoItemID { get; set; }
    }
}
