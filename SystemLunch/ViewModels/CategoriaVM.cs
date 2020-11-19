using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SystemBeauty.Models;

namespace SystemBeauty.ViewModels
{
    public class CategoriaVM
    {
        public int ID { get; set; }
        public bool Excluir { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataExclusao { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        [StringLength(300)]
        public string Descricao { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
