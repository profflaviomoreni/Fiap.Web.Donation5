using Fiap.Web.Donation5.Data;
using Fiap.Web.Donation5.Models;
using Fiap.Web.Donation5.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation5.Controllers
{
    public class CategoriaController : Controller
    {

        private readonly CategoriaRepository _categoriaRepository;

        public CategoriaController(DataContext context)
        {
            _categoriaRepository = new CategoriaRepository(context);
        }

        // GET: Categoria
        public async Task<IActionResult> Index()
        {
            return View(_categoriaRepository.FindAll());
        }

        // GET: Categoria/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaModel = _categoriaRepository.FindById(id);
            if (categoriaModel == null)
            {
                return NotFound();
            }

            return View(categoriaModel);
        }

        // GET: Categoria/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriaModel categoriaModel)
        {
            if (ModelState.IsValid)
            {
                _categoriaRepository.Insert(categoriaModel);

                return RedirectToAction(nameof(Index));
            }
            return View(categoriaModel);
        }

        // GET: Categoria/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaModel = _categoriaRepository.FindById(id);
            if (categoriaModel == null)
            {
                return NotFound();
            }
            return View(categoriaModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  CategoriaModel categoriaModel)
        {
            if (id != categoriaModel.CategoriaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _categoriaRepository.Update(categoriaModel);
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaModel);
        }

        // GET: Categoria/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaModel = _categoriaRepository.FindById(id);
            if (categoriaModel == null)
            {
                return NotFound();
            }

            return View(categoriaModel);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _categoriaRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
