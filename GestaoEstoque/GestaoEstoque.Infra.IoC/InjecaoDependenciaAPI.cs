using GestaoEstoque.Application.Interfaces;
using GestaoEstoque.Application.Mappings;
using GestaoEstoque.Application.Services;
using GestaoEstoque.Domain.Account;
using GestaoEstoque.Domain.Interfaces;
using GestaoEstoque.Infra.Data.Contexto;
using GestaoEstoque.Infra.Data.Identidade;
using GestaoEstoque.Infra.Data.Repositorios;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoEstoque.Infra.IoC
{
    public static class InjecaoDependenciaAPI
    {
        public static IServiceCollection AddInfraEstruturaAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AplicacaoDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection") + ";TrustServerCertificate=true",
                 b => b.MigrationsAssembly(typeof(AplicacaoDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
           .AddEntityFrameworkStores<AplicacaoDbContext>()
           .AddDefaultTokenProviders();

            services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
