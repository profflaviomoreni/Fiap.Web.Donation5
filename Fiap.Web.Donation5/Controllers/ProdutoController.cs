using Fiap.Web.Donation5.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation5.Controllers
{
    public class ProdutoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var produtos = ListarProdutosMock();

            return View(produtos);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var produto = ListarProdutosMock().Where( p => p.ProdutoId == id).FirstOrDefault();

            return View(produto);
        }

        [HttpPost]
        public IActionResult Edit(ProdutoModel produtoModel)
        {
            if ( string.IsNullOrEmpty(produtoModel.Descricao) )
            {
                ViewBag.ErrorMessage = "A descrição é requerida";
                return View(produtoModel);
            } else
            {
                TempData["SuccessMessage"] = $"O produto {produtoModel.NomeProduto} foi alterado com sucesso";
                return RedirectToAction(nameof(Index));
            }
        }





        private List<ProdutoModel> ListarProdutosMock()
        {
            // SELECT * FROM produtos ...
            var produtos = new List<ProdutoModel>{
                new ProdutoModel()
                {
                    ProdutoId = 1,
                    NomeProduto = "Iphone 11",
                    CategoriaId = 1,
                    Disponivel = true,
                    DataExpiracao = DateTime.Now,
                },
                new ProdutoModel()
                {
                    ProdutoId = 2,
                    NomeProduto = "Iphone 12",
                    CategoriaId = 2,
                    Disponivel = true,
                    DataExpiracao = DateTime.Now,
                },
                new ProdutoModel()
                {
                    ProdutoId = 3,
                    NomeProduto = "Iphone 13",
                    CategoriaId = 1,
                    Disponivel = true,
                    DataExpiracao = DateTime.Now,
                },
                new ProdutoModel()
                {
                    ProdutoId = 4,
                    NomeProduto = "Iphone 14",
                    CategoriaId = 1,
                    Disponivel = false,
                    DataExpiracao = DateTime.Now,
                },
            };

            return produtos;

        }
    }
}
