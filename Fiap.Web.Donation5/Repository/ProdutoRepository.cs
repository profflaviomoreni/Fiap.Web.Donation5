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

            return _dataContext.Produtos.AsNoTracking().ToList() ?? new List<ProdutoModel>();
        }

      
        public ProdutoModel FindById(int id)
        {
            return _dataContext.Produtos.Find(id);
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
