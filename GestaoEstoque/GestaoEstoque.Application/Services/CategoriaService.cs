using AutoMapper;
using GestaoEstoque.Application.DTOs;
using GestaoEstoque.Application.Interfaces;
using GestaoEstoque.Domain.Entidades;
using GestaoEstoque.Domain.Interfaces;

namespace GestaoEstoque.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private ICategoriaRepositorio _categoriaRepositorio;
        private readonly IMapper _mapper;
        public CategoriaService(ICategoriaRepositorio categoriaRepositorio, IMapper mapper)
        {
            _categoriaRepositorio = categoriaRepositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaDTO>> GetCategorias()
        {
            var categoriaEntity = await _categoriaRepositorio.TrazCategoriaAsync();
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categoriaEntity);
        }

        public async Task<CategoriaDTO> GetById(int id)
        {
            var categoriaEntity = await _categoriaRepositorio.TrazIdAsync(id);
            return _mapper.Map<CategoriaDTO>(categoriaEntity);
        }

        public async Task Add(CategoriaDTO categoriaDto)
        {
            var cateroriaEntity = _mapper.Map<Categoria>(categoriaDto);
            await _categoriaRepositorio.CriarAsync(cateroriaEntity);
        }

        public async Task Update(CategoriaDTO categoriaDto)
        {
            var categoriaEntity = _mapper.Map<Categoria>(categoriaDto);
            await _categoriaRepositorio.AlterarAsync(categoriaEntity);
        }

        public async Task Remove(int id)
        {
            var categoriaEntity = _categoriaRepositorio.TrazIdAsync(id).Result;
            await _categoriaRepositorio.ExcluirAsync(categoriaEntity);
        }
    }
}
