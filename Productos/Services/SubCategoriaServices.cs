using Productos.DTOs.SubCategorias;
using Productos.Services.Api;

namespace Productos.Services
{
    public class SubCategoriaServices : ISubCategoriaApi
    {
        public Task<SubCategoriaDTO> Actualizar(CrearSubCategoriaDTO subCategoriaDTO)
        {
            throw new NotImplementedException();
        }

        public Task<SubCategoriaDTO> Crear(CrearSubCategoriaDTO subCategoriaDTO)
        {
            throw new NotImplementedException();
        }

        public Task<SubCategoriaDTO> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SubCategoriaDTO> ObtenerSubCategoria(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SubCategoriaDTO>> ObtenersubCategorias()
        {
            throw new NotImplementedException();
        }
    }
}