using Microsoft.AspNetCore.Mvc;
using SystemBeauty.Models;
using SystemBeauty.Repositories.Interfaces;
using SystemBeauty.Services.Interfaces;
using SystemBeauty.ViewModels;

namespace SystemBeauty.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(IProdutoRepository produtoRepository, ICarrinhoCompra carrinhoCompra)
        {
            _produtoRepository = produtoRepository;
            _carrinhoCompra = carrinhoCompra;
        }
        public IActionResult Index(string ID)
        {
            var ListaProdutos = _carrinhoCompra.GetCarrinhoCompraItens(ID);

            var CarrinhoCompra = new CarrinhoCompraVM
            {
                CarrinhoCompraItens = ListaProdutos,
                Total = _carrinhoCompra.GetTotal(ID)
            };
            return View (CarrinhoCompra);
        }
        public RedirectToActionResult AddItemCarrinho (CarrinhoCompraItem item, string CarrinhoCompraID)
        {
            var produtoselecionado = _produtoRepository.GetProdutoById(item.ID);

            if (produtoselecionado != null)
            {
                _carrinhoCompra.Adicionar(produtoselecionado, item.Quantidade, CarrinhoCompraID);
            }
            return RedirectToAction("Index");
        }
        public IActionResult RemoverItemCarrinho (CarrinhoCompraItem item, string CarrinhoCompraID)
        {
            var produtoselecionado = _produtoRepository.GetProdutoById(item.ID);

            if (produtoselecionado != null)
            {
                _carrinhoCompra.Remover(produtoselecionado, item.Quantidade, CarrinhoCompraID);
            }
            return RedirectToAction("Index");
        }
    }
}
