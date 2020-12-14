using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SystemBeauty.Models;

namespace SystemBeauty.ViewModels
{
    public class PedidoVM
    {
        [BindNever]
        public int ID { get; set; }
        public List<ItensPedido> ItensPedido { get; set; }

        [Required(ErrorMessage = ("Informe o Nome."))]
        [Display(Name = "Nome")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = ("Informe o Endereço."))]
        [Display(Name = "Endereço")]
        [StringLength(100)]
        public string Endereco { get; set; }

        [Display(Name = "Complemento")]
        [StringLength(100)]
        public string Complemento { get; set; }

        [Required(ErrorMessage = ("Informe o CEP."))]
        [Display(Name = "CEP")]
        [StringLength(10)]
        public string Cep { get; set; }

        [Required(ErrorMessage = ("Informe o Estado."))]
        [Display(Name = "Estado")]
        [StringLength(20)]
        public string Estado { get; set; }

        [Required(ErrorMessage = ("Informe a Cidade."))]
        [Display(Name = "Cidade")]
        [StringLength(80)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = ("Informe um Telefone para contato."))]
        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(50)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = ("Informe um E-Mail válido."))]
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "Informe um e-mail válido.")]
        [StringLength(100)]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public decimal PedidoTotal { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime PedidoEnviado { get; set; }
        public CarrinhoCompra CarrinhoCompra { get; set; }
        public string CarrinhoCompraID { get; set; }
    }
}
