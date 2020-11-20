using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemBeauty.Models
{
    public class CarrinhoCompraItem
    {
        public int ID { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public string CarrinhoItemID { get; set; }
    }
}
