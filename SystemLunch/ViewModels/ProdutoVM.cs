using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SystemBeauty.Models;

namespace SystemBeauty.ViewModels
{
    public class ProdutoVM
    {
        [Display(Name ="Código")]
        public int ID { get; set; }
        public bool Excluir { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataExclusao { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [Display(Name ="Descrição")]
        [StringLength(500)]
        public string DescricaoCurta { get; set; }

        [Required]
        [Display(Name = "Adicional")]
        [StringLength(500)]
        public string DescricaoAdicional { get; set; }

        [Required]
        [Display(Name = "Descrição Completa")]
        [StringLength(1000)]
        public string DescricaoProduto { get; set; }

        [Required]
        [Display(Name = "Modo de Uso")]
        [StringLength(500)]
        public string ModoUso { get; set; }

        [Required]
        [Display(Name = "Ação e Benefício")]
        [StringLength(1000)]
        public string AcaoBeneficio { get; set; }

        [Required]
        [Display(Name = "Volume")]
        [StringLength(10)]
        public string VolumeEmbalagem { get; set; }

        [Required]
        [Display(Name = "Composição")]
        [StringLength(1000)]
        public string Composicao { get; set; }

        [Required]
        [Display(Name = "Indicação")]
        [StringLength(500)]
        public string Indicacao { get; set; }

        [Required]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Required]
        [Display(Name ="Imagem")]
        [StringLength(500)]
        public string ImageURL { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "ImagemTN")]
        public string ImageThumbNailURL { get; set; }

        [Required]
        [Display(Name = "Estoque")]
        public int QtdEstoque { get; set; }
        public bool ProdutoPreferido { get; set; }
        public bool EmEstoque { get; set; }

        [Required]
        public int CategoriaID { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
