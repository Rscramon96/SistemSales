using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SystemBeauty.Models;

namespace SystemBeauty.ViewModels
{
    public class CarrinhoCompraItemVM
    {
        [Required]
        public int ID { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        [StringLength(200)]
        public string CarrinhoItemID { get; set; }
    }
}
