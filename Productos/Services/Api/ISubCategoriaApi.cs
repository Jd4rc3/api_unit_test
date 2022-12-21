using Productos.DTOs.SubCategorias;

namespace Productos.Services.Api
{
    public interface ISubCategoriaApi
    {
        Task<SubCategoriaDTO> Actualizar(CrearSubCategoriaDTO categoriaDTO, int Id);

        Task<SubCategoriaDTO> Crear(CrearSubCategoriaDTO crearCategoriaDTO);

        Task<SubCategoriaDTO> Eliminar(int id);

        Task<SubCategoriaDTO> ObtenerSubCategoria(int id);

        Task<List<SubCategoriaDTO>> ObtenerSubCategorias();
    }
}