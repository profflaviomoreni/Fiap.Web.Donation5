using Fiap.Web.Donation5.Data;
using Fiap.Web.Donation5.Models;
using Fiap.Web.Donation5.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation5.Controllers
{
    public class TrocaController : BaseController
    {

        private readonly TrocaRepository _trocaRepository;

        private readonly ProdutoRepository _produtoRepository;

        public TrocaController(DataContext dataContext)
        {
            _trocaRepository = new TrocaRepository(dataContext);
            _produtoRepository = new ProdutoRepository(dataContext);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(TrocaModel trocaModel)
        {
            try
            {
                var produtoMeu = _produtoRepository.FindById(trocaModel.ProdutoIdMeu);
                var produtoEscolhido = _produtoRepository.FindById(trocaModel.ProdutoIdEscolhido);

                if ( ! produtoEscolhido.Disponivel )
                {
                    throw new Exception("Produto escolhido não encontra-se mais disponível");
                }

                if (!produtoMeu.Disponivel)
                {
                    throw new Exception("O seu produto já foi trocado anteriormente");
                }

                if ( (produtoMeu.Valor / produtoEscolhido.Valor ) < 0.9 )
                {
                    throw new Exception("Os valores dos produtos estão 10% acima da variação permitida");
                }
                
                if (produtoMeu.UsuarioId != UsuarioLogado.UsuarioId)
                {
                    throw new Exception("Ops, tentativa de fraude, selecione um produto da sua carteira");
                } 

                produtoEscolhido.Disponivel = false;
                _produtoRepository.Update(produtoEscolhido);

                produtoMeu.Disponivel = false;
                _produtoRepository.Update(produtoMeu);

                trocaModel.TrocaStatus = TrocaStatus.Iniciado;
                _trocaRepository.Insert(trocaModel);


                TempData["Sucesso"] = "Troca efetuada com sucesso";


            }
            catch (Exception ex)
            {
                TempData["Erro"] = $"Problema na troca: {ex.Message}";
            }

            return RedirectToAction(nameof(Index),"Home");
        }

    }
}
