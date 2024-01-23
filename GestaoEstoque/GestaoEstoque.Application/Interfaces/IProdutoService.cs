using GestaoEstoque.Application.DTOs;

namespace GestaoEstoque.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> GetProduto();
        Task<ProdutoDTO> GetById(int id);
        Task Add(ProdutoDTO produtoDto);
        Task Update(ProdutoDTO produtoDto);
        Task Remove(int id);
    }
}
