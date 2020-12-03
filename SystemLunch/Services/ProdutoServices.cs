using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemBeauty.Models;
using SystemBeauty.Repositories.Interfaces;
using SystemBeauty.Services.Interfaces;
using SystemBeauty.ViewModels;

namespace SystemBeauty.Services
{
    public class ProdutoServices : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public ProdutoServices(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }

        public Produto AddProduto(Produto produto)
        {
            return _produtoRepository.AddProduto(produto);
        }
        public Produto UpdateProduto(Produto produto)
        {
            return _produtoRepository.UpdateProduto(produto);
        }

        public Produto GetProdutoById(int ID)
        {
            return _produtoRepository.GetProdutoById(ID);
        }

        public IEnumerable<Categoria> ListaCategorias()
        {
            return _categoriaRepository.ListaCategorias();
        }
        public IEnumerable<Produto> ProdutoPorCategoria(int ID)
        {
            return _produtoRepository.ProdutoPorCategoria(ID);
        }
        public IEnumerable<Produto> ListaMaisVendidos()
        {
            return _produtoRepository.ListaMaisVendidos();
        }
        public IEnumerable<ProdutoVM> ListaProduto()
        {
            var produtos = _produtoRepository.ListaProdutos();

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
