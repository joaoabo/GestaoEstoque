using GestaoEstoque.Domain.Entidades;
using GestaoEstoque.Domain.Interfaces;
using GestaoEstoque.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;

namespace GestaoEstoque.Infra.Data.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        AplicacaoDbContext _produtoContext;
        public ProdutoRepositorio(AplicacaoDbContext contexto)
        {
            _produtoContext = contexto;
        }
        public async Task<Produto> TrazIdAsync(int id)
        {
            return await _produtoContext.Produtos.Include(c => c.Categoria).SingleOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IEnumerable<Produto>> TrazProdutoAsync()
        {
            return await _produtoContext.Produtos.ToListAsync();
        }
        public async Task<Produto> CriarAsync(Produto produto)
        {
            _produtoContext.Add(produto);
            await _produtoContext.SaveChangesAsync();
            return produto;
        }
        public async Task<Produto> AlterarAsync(Produto produto)
        {
            _produtoContext.Update(produto);
            await _produtoContext.SaveChangesAsync();
            return produto;
        }
        public async Task<Produto> ExcluirAsync(Produto produto)
        {
           _produtoContext.Remove(produto);
            await _produtoContext.SaveChangesAsync();
            return produto;
        }
    }
}
