﻿using GestaoEstoque.Application.DTOs;

namespace GestaoEstoque.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDTO>> GetCategorias();
        Task<CategoriaDTO> GetById(int id);
        Task Add(CategoriaDTO categoriaDto);
        Task Update(CategoriaDTO categoriaDto);
        Task Remove(int id);
    }
}
