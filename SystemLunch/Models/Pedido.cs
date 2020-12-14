using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SystemBeauty.Models
{
    public class Pedido
    {
        public int ID { get; set; }
        public List<ItensPedido> ItensPedido { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CarrinhoCompraID { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PedidoTotal { get; set; }
        public DateTime PedidoEnviado { get; set; }
    }
}
