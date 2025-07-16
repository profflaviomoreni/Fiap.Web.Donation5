using Fiap.Web.Donation5.Data;
using Fiap.Web.Donation5.Models;

namespace Fiap.Web.Donation5.Repository
{
    public class CategoriaRepository
    {

        private readonly DataContext _dataContext;
        public CategoriaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;        
        }


        public CategoriaModel FindById(int id)
        {
            return _dataContext.Categorias.Find(id);
        }

        public IList<CategoriaModel> FindAll()
        {
            return _dataContext.Categorias.ToList() ?? new List<CategoriaModel>();
        }

        public int Insert(CategoriaModel categoriaModel)
        {
            _dataContext.Categorias.Add(categoriaModel);
            _dataContext.SaveChanges();

            return categoriaModel.CategoriaId;
        }

        public void Update(CategoriaModel categoriaModel)
        {
            _dataContext.Categorias.Update(categoriaModel);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            //var categoria = new CategoriaModel()
            //{
            //    CategoriaId = id
            //};

            var categoria = FindById(id);
            _dataContext.Categorias.Remove(categoria);
            _dataContext.SaveChanges();

        }




    }
}
