using GestaoEstoque.Domain.Entidades;
using GestaoEstoque.Domain.Interfaces;
using GestaoEstoque.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;

namespace GestaoEstoque.Infra.Data.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        // 2° estancio meu"AplicacaoDbContext" pra usar dentro sa class 
        AplicacaoDbContext _categoriaContext;

        // 1° dentro do meu construtor injeto meu "AplicacaoDbContext"
        public CategoriaRepositorio(AplicacaoDbContext contexto)
        {
            _categoriaContext = contexto;
        }
        public async Task<IEnumerable<Categoria>> TrazCategoriaAsync()
        {
            return await _categoriaContext.Categorias.ToListAsync();
        }
        public async Task<Categoria> TrazIdAsync(int id)
        {
            return await _categoriaContext.Categorias.FindAsync(id);
        }
        public async Task<Categoria> CriarAsync(Categoria categoria)
        {
            _categoriaContext.Add(categoria);
            await _categoriaContext.SaveChangesAsync();
            return categoria;
        }
        public async Task<Categoria> AlterarAsync(Categoria categoria)
        {
            _categoriaContext.Update(categoria);
            await _categoriaContext.SaveChangesAsync();
            return categoria;
        }
        public async Task<Categoria> ExcluirAsync(Categoria categoria)
        {
            _categoriaContext.Remove(categoria);
            await _categoriaContext.SaveChangesAsync();
            return categoria;
        }
    }
}
