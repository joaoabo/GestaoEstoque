using GestaoEstoque.Application.DTOs;
using GestaoEstoque.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet] 
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
        {
            var categorias = await _categoriaService.GetCategorias();

            if(categorias == null)
            {
                return BadRequest("Categoria não encontrada");
            }
            return Ok(categorias);
        }
    }
}
