using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemBeauty.Models
{
    public class Categoria
    {
        public int ID { get; set; }
        public bool Excluir { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataExclusao { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<Produto> Produtos { get; set; } 
    }
}
