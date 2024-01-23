using AutoMapper;
using GestaoEstoque.Application.DTOs;
using GestaoEstoque.Domain.Entidades;

namespace GestaoEstoque.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
        }
    }
}
