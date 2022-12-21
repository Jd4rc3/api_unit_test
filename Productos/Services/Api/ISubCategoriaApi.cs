using Productos.DTOs.Categorias;
using Productos.DTOs.SubCategorias;

namespace Productos.Services.Api
{
    public interface ISubCategoriaApi
    {
        Task<SubCategoriaDTO> Actualizar(CrearSubCategoriaDTO subCategoriaDTO);

        Task<SubCategoriaDTO> Crear(CrearSubCategoriaDTO subCategoriaDTO);

        Task<SubCategoriaDTO> Eliminar(int id);

        Task<SubCategoriaDTO> ObtenerSubCategoria(int id);

        Task<List<SubCategoriaDTO>> ObtenersubCategorias();
    }
}