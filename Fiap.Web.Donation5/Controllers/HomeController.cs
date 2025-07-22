using System.Diagnostics;
using Fiap.Web.Donation5.Controllers.Filters;
using Fiap.Web.Donation5.Data;
using Fiap.Web.Donation5.Models;
using Fiap.Web.Donation5.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation5.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ProdutoRepository _produtoRepository;

        public HomeController(DataContext dataContext, ILogger<HomeController> logger)
        {
            _logger = logger;
            _produtoRepository = new ProdutoRepository(dataContext);
        }

        public IActionResult Index()
        {
            IList<ProdutoModel> produtos = new List<ProdutoModel>();

            if ( Autenticado )
            {
                produtos = _produtoRepository.FindAllAvailablesForChangeWithCategoriaAndUsuario(UsuarioLogado.UsuarioId);
            } else
            {
                produtos = _produtoRepository.FindAllAvailablesWithCategoriaAndUsuario();
            }

            return View(produtos);
        }

        [Autenticado]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
