using Fiap.Web.Donation5.Data;
using Fiap.Web.Donation5.Models;
using Fiap.Web.Donation5.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation5.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly int UserId = 1;


        private readonly ProdutoRepository _produtoRepository;
        private readonly CategoriaRepository _categoriaRepository;

        public ProdutoController(DataContext dataContext)
        {
            _produtoRepository = new ProdutoRepository(dataContext);
            _categoriaRepository = new CategoriaRepository(dataContext);
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
            var categorias = _categoriaRepository.FindAll();
            ViewBag.Categorias = categorias;

            return View(new ProdutoModel());
        }

        [HttpPost]
        public IActionResult Create(ProdutoModel produtoModel)
        {

            produtoModel.UsuarioId = UserId;

            if (ModelState.IsValid)
            {
                _produtoRepository.Insert(produtoModel);

                var mensagem = $"O produto {produtoModel.NomeProduto} foi inserido com sucesso";
                TempData["SuccessMessage"] = mensagem;
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var categorias = _categoriaRepository.FindAll();
                ViewBag.Categorias = categorias;

                return View(new ProdutoModel());
            }

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var produto = _produtoRepository.FindById(id);

            var categorias = _categoriaRepository.FindAll();
            ViewBag.Categorias = categorias;

            return View(produto);
        }


        [HttpPost]
        public IActionResult Edit(ProdutoModel produtoModel)
        {
            if (ModelState.IsValid)
            {
                produtoModel.UsuarioId = UserId;
                _produtoRepository.Update(produtoModel);

                TempData["MensagemSucesso"] = $"Produto {produtoModel.NomeProduto} alterado com sucesso";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.MensagemErro = "Preencha todos os dados corretamente";

                var categorias = _categoriaRepository.FindAll();
                ViewBag.Categorias = categorias;

                return View(produtoModel);
            }

        }


        [HttpGet]
        public IActionResult Detalhe(int id)
        {
            var produto = _produtoRepository.FindById(id);
            return View(produto);
        }


        private void LoadCategoriasCombo()
        {
            var categorias = _categoriaRepository.FindAll();
            ViewBag.Categorias = categorias;
        }

    }
}
