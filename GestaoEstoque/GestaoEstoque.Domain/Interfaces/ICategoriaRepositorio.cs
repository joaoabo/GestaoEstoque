using GestaoEstoque.Domain.Entidades;

namespace GestaoEstoque.Domain.Interfaces
{
    public interface ICategoriaRepositorio
    {
        Task<IEnumerable<Categoria>> TrazCategoriaAsync();
        Task<Categoria> TrazIdAsync(int id);
        Task<Categoria> CriarAsync(Categoria categoria);
        Task<Categoria> AlterarAsync(Categoria categoria);
        Task<Categoria> ExcluirAsync(Categoria categoria);
    }
}
