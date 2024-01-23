using GestaoEstoque.Domain.Entidades;

namespace GestaoEstoque.Domain.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<IEnumerable<Produto>> TrazProdutoAsync();
        Task<Produto> TrazIdAsync(int id);
        Task<Produto> CriarAsync(Produto produto);
        Task<Produto> AlterarAsync(Produto produto);
        Task<Produto> ExcluirAsync(Produto produto);
    }
}
