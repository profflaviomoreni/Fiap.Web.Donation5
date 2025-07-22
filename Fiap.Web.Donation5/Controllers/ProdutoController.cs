using Fiap.Web.Donation5.Controllers.Filters;
using Fiap.Web.Donation5.Data;
using Fiap.Web.Donation5.Models;
using Fiap.Web.Donation5.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.Donation5.Controllers
{

    [Autenticado]
    public class ProdutoController : BaseController
    {

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
            var produtos = _produtoRepository.FindAllWithCategoriaAndUsuario();
            //var produtos = _produtoRepository.FindAllAvailablesWithCategoriaAndUsuario();
            //var produtos = _produtoRepository.FindAllAvailablesWithCategoriaAndUsuarioByUserId(2);
            //var produtos = _produtoRepository.FindAllAvailablesForChangeWithCategoriaAndUsuario(2);
            //var produtos = _produtoRepository.FindAllWithCategoriaAndUsuarioByName("Iphone");

            return View(produtos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadCategoriasCombo();
            return View(new ProdutoModel());
        }

        [HttpPost]
        public IActionResult Create(ProdutoModel produtoModel)
        {

            produtoModel.UsuarioId = UsuarioLogado.UsuarioId;

            if (ModelState.IsValid)
            {
                _produtoRepository.Insert(produtoModel);

                var mensagem = $"O produto {produtoModel.NomeProduto} foi inserido com sucesso";
                TempData["SuccessMessage"] = mensagem;
                return RedirectToAction(nameof(Index));
            }
            else
            {
                LoadCategoriasCombo();
                return View(new ProdutoModel());
            }

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var produto = _produtoRepository.FindById(id);
            LoadCategoriasCombo();
            return View(produto);
        }


        [HttpPost]
        public IActionResult Edit(ProdutoModel produtoModel)
        {
            if (ModelState.IsValid)
            {
                produtoModel.UsuarioId = UsuarioLogado.UsuarioId;
                _produtoRepository.Update(produtoModel);

                TempData["MensagemSucesso"] = $"Produto {produtoModel.NomeProduto} alterado com sucesso";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.MensagemErro = "Preencha todos os dados corretamente";
                LoadCategoriasCombo();
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
            var selectCategorias = new SelectList(categorias, "CategoriaId", "NomeCategoria");
            ViewBag.Categorias = selectCategorias;
        }

    }
}
