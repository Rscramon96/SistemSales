using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SystemBeauty.Data;
using SystemBeauty.Models;
using SystemBeauty.Repositories;
using SystemBeauty.Repositories.Interfaces;
using SystemBeauty.Services;
using SystemBeauty.Services.Interfaces;

namespace SystemBeauty
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddDbContext<SBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<ICategoriaRepository, CategoriaRepositoryRP>();
            services.AddTransient<IProdutoRepository, ProdutoRepositoryRP>();
            services.AddTransient<ICarrinhoCompraItemRepository, CarrinhoCompraItemRP>();

            services.AddTransient<ICarrinhoCompraService, CarrinhoCompraServices>();
            services.AddTransient<IProdutoService, ProdutoServices>();
            services.AddTransient<ICategoriaService, CategoriaServices>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped(CP => CarrinhoCompra.GetCarrinho(CP));
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
