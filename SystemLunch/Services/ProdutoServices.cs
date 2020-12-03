using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemBeauty.Models;
using SystemBeauty.Services.Interfaces;
using SystemBeauty.ViewModels;

namespace SystemBeauty.Services
{
    public class ProdutoServices : IProdutoService
    {
        private readonly IProdutoService _produtõ;

        public ProdutoServices(IProdutoService produto)
        {
            _produtõ = produto;
        }

        public Produto ExcluirProduto(Produto produto)
        {
            produto.DataExclusao = DateTime.Now;
            produto.Excluir = true;

            return produto;
        }

        public IEnumerable<ProdutoVM> ListaProduto(IEnumerable<Produto> produtos)
        {
            List<ProdutoVM> lista = new List<ProdutoVM>();
            foreach (var item in produtos)
            {
                ProdutoVM produtoVM = new ProdutoVM();
                produtoVM.ID = item.ID;
                produtoVM.Nome = item.Nome;
                produtoVM.DescricaoCurta = item.DescricaoCurta;
                produtoVM.VolumeEmbalagem = item.VolumeEmbalagem;
                produtoVM.Preco = item.Preco;
                produtoVM.ImageURL = item.ImageURL;
                produtoVM.QtdEstoque = item.QtdEstoque;
                lista.Add(produtoVM);
            }
            return lista;
        }

        public Produto ProdutoVM_To_Produto(ProdutoVM produtoVM)
        {
            var produto = new Produto();

            produto.ID = produtoVM.ID;
            produto.DataExclusao = produtoVM.DataExclusao;
            produto.Excluir = produto.Excluir;
            produto.DataCadastro = produtoVM.DataCadastro;
            produto.Nome = produtoVM.Nome;
            produto.DescricaoCurta = produtoVM.DescricaoCurta;
            produto.DescricaoAdicional = produtoVM.DescricaoAdicional;
            produto.DescricaoProduto = produtoVM.DescricaoProduto;
            produto.ModoUso = produtoVM.ModoUso;
            produto.AcaoBeneficio = produtoVM.AcaoBeneficio;
            produto.VolumeEmbalagem = produtoVM.VolumeEmbalagem;
            produto.Composicao = produtoVM.Composicao;
            produto.Indicacao = produtoVM.Indicacao;
            produto.Preco = produtoVM.Preco;
            produto.ImageURL = produtoVM.ImageURL;
            produto.ImageThumbNailURL = produtoVM.ImageThumbNailURL;
            produto.QtdEstoque = produtoVM.QtdEstoque;
            produto.CategoriaID = produtoVM.CategoriaID;

            return produto;
        }

        public ProdutoVM Produto_To_ProdutoVM(Produto produto)
        {
            var produtoVM = new ProdutoVM();

            produtoVM.ID = produto.ID;
            produtoVM.DataExclusao = produto.DataExclusao;
            produtoVM.Excluir = produto.Excluir;
            produtoVM.DataCadastro = produto.DataCadastro;
            produtoVM.Nome = produto.Nome;
            produtoVM.DescricaoCurta = produto.DescricaoCurta;
            produtoVM.DescricaoAdicional = produto.DescricaoAdicional;
            produtoVM.DescricaoProduto = produto.DescricaoProduto;
            produtoVM.ModoUso = produto.ModoUso;
            produtoVM.AcaoBeneficio = produto.AcaoBeneficio;
            produtoVM.VolumeEmbalagem = produto.VolumeEmbalagem;
            produtoVM.Composicao = produto.Composicao;
            produtoVM.Indicacao = produto.Indicacao;
            produtoVM.Preco = produto.Preco;
            produtoVM.ImageURL = produto.ImageURL;
            produtoVM.ImageThumbNailURL = produto.ImageThumbNailURL;
            produtoVM.QtdEstoque = produto.QtdEstoque;
            produtoVM.CategoriaID = produto.CategoriaID;

            return produtoVM;
        }
    }
}
