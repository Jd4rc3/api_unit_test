using Productos.DTOs.Categorias;

namespace Productos.Services.Api
{
    public interface ICategoriaApi
    {
        Task<CategoriaDTO> Actualizar(CrearCategoriaDTO categoriaDTO);

        Task<CategoriaDTO> Crear(CrearCategoriaDTO crearCategoriaDTO);

        Task<CategoriaDTO> Eliminar(int id);

        Task<CategoriaDTO> ObtenerCategoria(int id);

        Task<List<CategoriaDTO>> ObtenerCategorias();
    }
}