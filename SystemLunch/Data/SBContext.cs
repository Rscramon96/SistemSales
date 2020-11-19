using Microsoft.EntityFrameworkCore;
using SystemBeauty.Models;
using SystemBeauty.ViewModels;

namespace SystemBeauty.Data
{
    public class SBContext : DbContext 
    {
        public SBContext (DbContextOptions<SBContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<SystemBeauty.ViewModels.ProdutoVM> ProdutoVM { get; set; }

    }
}
