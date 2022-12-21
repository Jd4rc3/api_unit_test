using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Productos.DTOs.Categorias;
using Productos.Models;
using Productos.Services.Api;

namespace Productos.Services
{
    public class CategoriaService : ICategoriaApi
    {
        private readonly Contexto contexto;
        private readonly IMapper mapper;

        public CategoriaService(Contexto contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        public async Task<CategoriaDTO> Actualizar(CrearCategoriaDTO categoriaDTO, int id)
        {
            var categoria = mapper.Map<Categoria>(categoriaDTO);

            categoria.Id = id;

            contexto.Update(categoria);

            await contexto.SaveChangesAsync();

            return mapper.Map<CategoriaDTO>(categoria);
        }

        public async Task<CategoriaDTO> Crear(CrearCategoriaDTO crearCategoriaDTO)
        {
            var categoria = mapper.Map<Categoria>(crearCategoriaDTO);

            contexto.Add(categoria);

            var id = await contexto.SaveChangesAsync();

            categoria.Id = id;

            return mapper.Map<CategoriaDTO>(categoria);
        }

        public async Task<CategoriaDTO> Eliminar(int id)
        {
            var categoria = await contexto.Categorias.FirstOrDefaultAsync(x => x.Id == id);

            if (categoria == null)
            {
                return null;
            }

            contexto.Remove(categoria);

            await contexto.SaveChangesAsync();

            return mapper.Map<CategoriaDTO>(categoria);
        }

        public async Task<CategoriaDTO> ObtenerCategoria(int id)
        {
            var categoria = await contexto.Categorias.FirstOrDefaultAsync(c => c.Id == id);


            return mapper.Map<CategoriaDTO>(categoria);
        }

        public async Task<List<CategoriaDTO>> ObtenerCategorias()
        {
            var categorias = await contexto.Categorias.ToListAsync();

            return mapper.Map<List<CategoriaDTO>>(categorias);
        }
    }
}