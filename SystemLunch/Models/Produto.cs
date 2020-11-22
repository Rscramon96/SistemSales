using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SystemBeauty.Models
{
    public class Produto
    {
        public int ID { get; set; }
        public bool Excluir { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataExclusao { get; set; }
        public string Nome { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoAdicional { get; set; }
        public string DescricaoProduto { get; set; }
        public string ModoUso { get; set; }
        public string AcaoBeneficio { get; set; }
        public string VolumeEmbalagem { get; set; }
        public string Composicao { get; set; }
        public string Indicacao { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }
        public string ImageURL { get; set; }
        public string ImageThumbNailURL { get; set; }
        public int QtdEstoque { get; set; }
        public bool EmEstoque { get; set; }
        public int QtdVendido { get; set; }
        public int CategoriaID { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}