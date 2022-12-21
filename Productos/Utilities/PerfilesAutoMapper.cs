using AutoMapper;
using Productos.DTOs.Categorias;
using Productos.DTOs.SubCategorias;
using Productos.Models;

namespace Productos.Utilities
{
    public class PerfilesAutoMapper : Profile
    {
        public PerfilesAutoMapper()
        {
            CreateMap<CrearCategoriaDTO, Categoria>();
            CreateMap<Categoria, CategoriaDTO>();

            CreateMap<CrearSubCategoriaDTO, Subcategoria>();
            CreateMap<Subcategoria, SubCategoriaDTO>();
        }
    }
}