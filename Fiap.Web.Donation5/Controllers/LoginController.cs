using Fiap.Web.Donation5.Controllers.Filters;
using Fiap.Web.Donation5.Data;
using Fiap.Web.Donation5.Models;
using Fiap.Web.Donation5.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Fiap.Web.Donation5.Controllers
{
    public class LoginController : Controller
    {
        private readonly UsuarioRepository _usuarioRepository;

        public LoginController(DataContext dataContext)
        {
            _usuarioRepository = new UsuarioRepository(dataContext);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(UsuarioModel usuarioModel) {


            try
            {

                if (!string.IsNullOrEmpty(usuarioModel.Email) && !string.IsNullOrEmpty(usuarioModel.Senha))
                {
                    var usuario = _usuarioRepository.FindByUserAndPassword(usuarioModel.Email, usuarioModel.Senha);

                    if (usuario != null)
                    {
                        usuario.Senha = string.Empty;
                        var usuarioJson = JsonSerializer.Serialize(usuario);
                        HttpContext.Session.SetString("usuarioLogado", usuarioJson);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        throw new Exception("Usuário ou senha inválida");
                    }

                } else
                {
                    throw new Exception("Usuário e Senha são obrigatórios");
                }


            }
            catch (Exception ex)
            {
                ViewBag.Mensagem = ex.Message;
                return View(usuarioModel);
            }


        }


        [HttpGet]
        [Autenticado]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index));
        }

    }
}
