using Fiap.Web.Donation5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Fiap.Web.Donation5.Controllers
{
    public class BaseController : Controller
    {

        protected UsuarioModel? UsuarioLogado { 
            get {
                var json = HttpContext.Session.GetString("usuarioLogado");
                if ( ! string.IsNullOrEmpty(json))
                {
                    return JsonSerializer.Deserialize<UsuarioModel>(json);
                } else
                {
                    return null;
                }
            }  
        }


        public bool Autenticado =>  UsuarioLogado != null;

    }
}
