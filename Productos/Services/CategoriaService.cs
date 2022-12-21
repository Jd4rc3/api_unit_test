using AutoMapper;
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

        public Task<CategoriaDTO> Actualizar(CrearCategoriaDTO categoriaDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoriaDTO> Crear(CrearCategoriaDTO crearCategoriaDTO)
        {
            var categoria = mapper.Map<Categoria>(crearCategoriaDTO);

            contexto.Add(categoria);

            var id = await contexto.SaveChangesAsync();

            categoria.Id = id;

            return mapper.Map<CategoriaDTO>(categoria);
        }

        public Task<CategoriaDTO> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoriaDTO> ObtenerCategoria(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoriaDTO>> ObtenerCategorias()
        {
            throw new NotImplementedException();
        }
    }
}