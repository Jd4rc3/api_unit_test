using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Productos.DTOs.SubCategorias;
using Productos.Models;
using Productos.Services.Api;

namespace Productos.Services
{
    public class SubCategoriaServices : ISubCategoriaApi
    {

        private readonly Contexto contexto;

        private readonly IMapper mapper;

        public SubCategoriaServices(Contexto contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        public async Task<SubCategoriaDTO> Actualizar(CrearSubCategoriaDTO categoriaDTO, int Id)
        {
            var subCategoria = mapper.Map<Subcategoria>(categoriaDTO);

            contexto.Update(subCategoria);

            await contexto.SaveChangesAsync();

            return mapper.Map<SubCategoriaDTO>(subCategoria);
        }

        public async Task<SubCategoriaDTO> Crear(CrearSubCategoriaDTO crearCategoriaDTO)
        {
            var subCategoria = mapper.Map<Subcategoria>(crearCategoriaDTO);

            contexto.Add(subCategoria);

            var id = await contexto.SaveChangesAsync();

            subCategoria.Id = id;

            return mapper.Map<SubCategoriaDTO>(subCategoria);
        }

        public async Task<SubCategoriaDTO> Eliminar(int id)
        {
            var subCategoria = await contexto.Subcategorias.FirstOrDefaultAsync<Subcategoria>(s => s.Id == id);

            if (subCategoria == null)
            {
                return null;
            }

            contexto.Remove(subCategoria);

            await contexto.SaveChangesAsync();

            return mapper.Map<SubCategoriaDTO>(subCategoria);
        }

        public async Task<SubCategoriaDTO> ObtenerSubCategoria(int id)
        {
            var subCategoria = await contexto.Subcategorias.FirstOrDefaultAsync(s => s.Id == id);

            return mapper.Map<SubCategoriaDTO>(subCategoria);
        }

        public async Task<List<SubCategoriaDTO>> ObtenerSubCategorias()
        {
            var subCategorias = await contexto.Subcategorias.ToListAsync();

            return mapper.Map<List<SubCategoriaDTO>>(subCategorias);
        }
    }
}