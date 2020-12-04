using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemBeauty.Services.Interfaces;

namespace SystemBeauty.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaMenu(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_categoriaService.ListaCategorias());
        }
    }
}
