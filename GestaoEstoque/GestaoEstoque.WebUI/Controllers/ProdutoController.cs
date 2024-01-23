using GestaoEstoque.Application.DTOs;
using GestaoEstoque.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestaoEstoque.WebUI.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly ICategoriaService _categoriaService;
        private readonly IWebHostEnvironment _environment;

        public ProdutoController(IProdutoService produtoService, ICategoriaService categoriaService, IWebHostEnvironment environment)
        {
            _produtoService = produtoService;
            _categoriaService = categoriaService;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var produto = await _produtoService.GetProduto();
            return View(produto);
        }

        [HttpGet()]
        public async Task<IActionResult> Criar()
        {
            ViewBag.CategoriaId = new SelectList(await _categoriaService.GetCategorias(), "Id", "Nome");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(ProdutoDTO produtoDTO)
        {
            if(ModelState.IsValid)
            {
                await _produtoService.Add(produtoDTO);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.CategoriaId = new SelectList(await _categoriaService.GetCategorias(), "Id", "Nome");
            }
            return View(produtoDTO);
        }

        [HttpGet()]
        public async Task<IActionResult> Editar(int id)
        {
            if (id == null)
                return NotFound("produto não encontrado");

            var produtoDTO = await _produtoService.GetById(id);

            if (produtoDTO == null)
                return NotFound();

            var categoria = await _categoriaService.GetCategorias();
            ViewBag.CategoriaId = new SelectList(categoria, "Id", "Nome", produtoDTO.CategoriaId);

            return View(produtoDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(ProdutoDTO produtoDTO)
        {
            if (ModelState.IsValid)
            {
                await _produtoService.Update(produtoDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(produtoDTO);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Deletar(int id)
        {
            if (id == null) return NotFound();

            var produtoDTO = await _produtoService.GetById(id);

            if (produtoDTO == null) return NotFound();

            return View(produtoDTO);
        }

        [HttpPost(), ActionName("Deletar")]
        public async Task<IActionResult> DeletarConfirmacao(int id)
        {
            await _produtoService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detalhes(int id)
        {
            if (id == null) return NotFound();
            var produtoDTO = await _produtoService.GetById(id);

            if (produtoDTO == null) return NotFound();

            var wwwroot = _environment.WebRootPath;
            var imagem = Path.Combine(wwwroot,"image\\"+ produtoDTO.Imagem);
            var existe = System.IO.File.Exists(imagem);
            ViewBag.ImagemExiste = existe;

            return View(produtoDTO);
        }
    }
}