using GestaoEstoque.Domain.Entidades;
using GestaoEstoque.Infra.Data.Identidade;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestaoEstoque.Infra.Data.Contexto
{
    //public class AplicacaoDbContext : DbContext
    public class AplicacaoDbContext : IdentityDbContext<ApplicationUser>
    {
        public AplicacaoDbContext(DbContextOptions<AplicacaoDbContext> options) : base(options)
        {
                
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AplicacaoDbContext).Assembly);
        }
    }
}
