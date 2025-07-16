using Fiap.Web.Donation5.Data;
using Fiap.Web.Donation5.Models;
using Fiap.Web.Donation5.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation5.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly int UserId = 1;

        private readonly DataContext _dataContext;
        private readonly ProdutoRepository _produtoRepository;

        public ProdutoController(DataContext dataContext)
        {
            _dataContext = dataContext;
            _produtoRepository = new ProdutoRepository(dataContext);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var produtos = _produtoRepository.FindAll();
            return View(produtos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ProdutoModel());
        }

        [HttpPost]
        public IActionResult Create(ProdutoModel produtoModel)
        {

            produtoModel.UsuarioId = UserId;

            if (ModelState.IsValid)
            {
                _dataContext.Produtos.Add(produtoModel);
                _dataContext.SaveChanges();

                var mensagem = $"O produto {produtoModel.NomeProduto} foi inserido com sucesso";
                TempData["SuccessMessage"] = mensagem;
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(new ProdutoModel());
            }

        }


        [HttpGet]
        public IActionResult Editar(int id)
        {
            var produto = _produtoRepository.FindById(id);
            return View(produto);
        }


        [HttpPost]
        public IActionResult Editar(ProdutoModel produtoModel)
        {
            produtoModel.UsuarioId = UserId;

            if (string.IsNullOrEmpty(produtoModel.NomeProduto))
            {
                var mensagem = "O campo Nome é requerido, favor preencher";
                ViewBag.ErrorMessage = mensagem;
                return View(produtoModel);
            }
            else
            {
                var mensagem = $"O produto {produtoModel.NomeProduto} foi alterado com sucesso";
                TempData["SuccessMessage"] = mensagem;
                return RedirectToAction(nameof(Index));
            }

        }


        [HttpGet]
        public IActionResult Detalhe(int id)
        {
            var produto = _produtoRepository.FindById(id);
            return View(produto);
        }

    }
}
