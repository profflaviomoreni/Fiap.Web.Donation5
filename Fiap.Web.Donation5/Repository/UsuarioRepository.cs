using Fiap.Web.Donation5.Data;
using Fiap.Web.Donation5.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Donation5.Repository
{
    public class UsuarioRepository
    {

        private readonly DataContext _dataContext;

        public UsuarioRepository(DataContext dataContext)
        {
            _dataContext = dataContext;                
        }


        public UsuarioModel FindByUserAndPassword(string username, string password)
        {
            var usuarioModel = _dataContext.Usuarios.AsNoTracking()
                                    .Where( u => u.Email == username && u.Senha == password )
                                    .FirstOrDefault();

            return usuarioModel;
        }

    }
}
