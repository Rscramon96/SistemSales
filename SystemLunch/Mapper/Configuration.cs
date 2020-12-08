using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SystemBeauty.Models;
using SystemBeauty.ViewModels;

namespace SystemBeauty.AutoMapper
{
    public class Configuration : Profile
    {
        public Configuration()
        {
            CreateMap<ProdutoVM, Produto>().ReverseMap();
            CreateMap<CategoriaVM, Categoria>().ReverseMap();
            CreateMap<CarrinhoCompraVM, CarrinhoCompra>().ReverseMap();
            CreateMap<CarrinhoCompraItemVM, CarrinhoCompraItem>().ReverseMap();
        }
    }
}
