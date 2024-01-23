using GestaoEstoque.Application.DTOs;
using GestaoEstoque.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEstoque.WebUI.Controllers
{
    [Authorize]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaService.GetCategorias();
            return View(categorias);
        }

        [HttpGet()]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(CategoriaDTO categoria)
        {
            if (ModelState.IsValid)
            {
                await _categoriaService.Add(categoria);
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            if (id == null) return NotFound();

            var categoriaDTO = await _categoriaService.GetById(id);

            if (categoriaDTO == null) return NotFound();

            return View(categoriaDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(CategoriaDTO categoriaDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoriaService.Update(categoriaDTO);
                }catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Deletar(int id)
        {
            if (id == null)
                return NotFound();

            var categoriaDTO = await _categoriaService.GetById(id);

            if (categoriaDTO == null)
                return BadRequest("Erro");

            return View(categoriaDTO);
        }

        [HttpPost(), ActionName("Deletar")]
        public async Task<IActionResult> DeletarConfirmacao(int id)
        {
            await _categoriaService.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Detalhes(int id)
        {
            if(id == null)
                return NotFound();

            var categoriaDTO = await _categoriaService.GetById(id);

            if (categoriaDTO == null)
                return NotFound();

            return View(categoriaDTO);
        }
    }
}
