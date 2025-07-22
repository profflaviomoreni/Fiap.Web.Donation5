using Fiap.Web.Donation5.Data;
using Fiap.Web.Donation5.Models;

namespace Fiap.Web.Donation5.Repository
{
    public class TrocaRepository
    {

        private readonly DataContext _context;

        public TrocaRepository(DataContext dataContext)
        {
            _context = dataContext;        
        }


        public Guid Insert(TrocaModel trocalModel)
        {
            _context.Trocas.Add(trocalModel);
            _context.SaveChanges();

            return trocalModel.TrocaId;
        }

    }
}
