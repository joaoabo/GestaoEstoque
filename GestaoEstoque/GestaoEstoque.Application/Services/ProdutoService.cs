using AutoMapper;
using GestaoEstoque.Application.DTOs;
using GestaoEstoque.Application.Interfaces;
using GestaoEstoque.Domain.Entidades;
using GestaoEstoque.Domain.Interfaces;

namespace GestaoEstoque.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private IProdutoRepositorio _produtoRepositorio;
        private readonly IMapper _mapper;
        public ProdutoService(IProdutoRepositorio produtoRepositorio, IMapper mapper)
        {
            _produtoRepositorio = produtoRepositorio ??
                throw new ArgumentNullException(nameof(produtoRepositorio));

            _mapper = mapper;
        }
        public async Task<IEnumerable<ProdutoDTO>> GetProduto()
        {
            var produtoEntity = await _produtoRepositorio.TrazProdutoAsync();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtoEntity);
        }

        public async Task<ProdutoDTO> GetById(int id)
        {
            var produtoEntity = await _produtoRepositorio.TrazIdAsync(id);
            return _mapper.Map<ProdutoDTO>(produtoEntity);
        }

        public async Task Add(ProdutoDTO produtoDto)
        {
            var produtoEntity = _mapper.Map<Produto>(produtoDto);
            await _produtoRepositorio.CriarAsync(produtoEntity);
        }

        public async Task Update(ProdutoDTO produtoDto)
        {
            var produtoEntity = _mapper.Map<Produto>(produtoDto);
            await _produtoRepositorio.AlterarAsync(produtoEntity);
        }

        public async Task Remove(int id)
        {
            var produtoEntity = _produtoRepositorio.TrazIdAsync(id).Result;
            await _produtoRepositorio.ExcluirAsync(produtoEntity);
        }
    }
}
