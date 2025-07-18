using Fiap.Web.Donation5.Data;
using Fiap.Web.Donation5.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Donation5.Repository
{
    public class ProdutoRepository
    {

        private readonly DataContext _dataContext;

        public ProdutoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public List<ProdutoModel> FindAll()
        {
            var produtos = _dataContext.Produtos.AsNoTracking().ToList();

            return produtos ?? new List<ProdutoModel>();
        }

        public List<ProdutoModel> FindAllWithCategoriaAndUsuario()
        {
            var produtos = _dataContext.Produtos.AsNoTracking()
                                .Include(c => c.Categoria) // INNER JOIN                                   
                                .Include(u => u.Usuario)   // INNER JOIN 
                                .ToList();

            return produtos ?? new List<ProdutoModel>();
        }

        public List<ProdutoModel> FindAllWithCategoriaAndUsuarioByName(string nomeParcial)
        {
            var produtos = _dataContext.Produtos.AsNoTracking()
                                .Where( p => 
                                    p.NomeProduto.ToLower().Contains(nomeParcial.ToLower()) &&
                                    p.Disponivel == true &&
                                    p.DataExpiracao >= DateTime.UtcNow
                                 )
                                .Include(c => c.Categoria) // INNER JOIN                                   
                                .Include(u => u.Usuario)   // INNER JOIN 
                                .ToList();

            return produtos ?? new List<ProdutoModel>();
        }


        public List<ProdutoModel> FindAllAvailablesWithCategoriaAndUsuario()
        {
            var produtos = _dataContext.Produtos.AsNoTracking()
                                .Where( p =>
                                    p.Disponivel == true &&
                                    p.DataExpiracao >= DateTime.UtcNow
                                )
                                .Include(c => c.Categoria) // INNER JOIN                                   
                                .Include(u => u.Usuario)   // INNER JOIN 
                                .ToList();

            return produtos ?? new List<ProdutoModel>();
        }

        public List<ProdutoModel> FindAllAvailablesWithCategoriaAndUsuarioByUserId(int userId)
        {
            var produtos = _dataContext.Produtos.AsNoTracking()
                                .Where(p =>
                                    p.Disponivel == true &&
                                    p.DataExpiracao >= DateTime.UtcNow &&
                                    p.UsuarioId == userId
                                )
                                .Include(c => c.Categoria) // INNER JOIN                                   
                                .Include(u => u.Usuario)   // INNER JOIN 
                                .ToList();

            return produtos ?? new List<ProdutoModel>();
        }

        public List<ProdutoModel> FindAllAvailablesForChangeWithCategoriaAndUsuario(int userId)
        {
            var produtos = _dataContext.Produtos.AsNoTracking()
                                .Where(p =>
                                    p.Disponivel == true &&
                                    p.DataExpiracao >= DateTime.UtcNow &&
                                    p.UsuarioId != userId
                                )
                                .Include(c => c.Categoria) // INNER JOIN                                   
                                .Include(u => u.Usuario)   // INNER JOIN 
                                .ToList();

            return produtos ?? new List<ProdutoModel>();
        }


        public ProdutoModel FindById(int id)
        {
            return _dataContext.Produtos.AsNoTracking()
                            .SingleOrDefault( p=> p.ProdutoId == id);
        }


        public int Insert(ProdutoModel ProdutoModel)
        {
            _dataContext.Produtos.Add(ProdutoModel);
            _dataContext.SaveChanges();

            return ProdutoModel.ProdutoId;
        }


        public void Update(ProdutoModel ProdutoModel)
        {
            _dataContext.Produtos.Update(ProdutoModel);
            _dataContext.SaveChanges();
        }


        public void Delete(int id)
        {
            var Produto = new ProdutoModel()
            {
                ProdutoId = id
            };

            _dataContext.Produtos.Remove(Produto);
            _dataContext.SaveChanges();

        }

    }
}
