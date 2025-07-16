using Fiap.Web.Donation5.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Donation5.Data
{
    public class DataContext : DbContext
    {

        public DbSet<CategoriaModel> Categorias { get; set; }

        public DbSet<UsuarioModel> Usuarios { get; set; }

        public DbSet<ProdutoModel> Produtos { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }


        protected DataContext()
        {
        }
    }
}
