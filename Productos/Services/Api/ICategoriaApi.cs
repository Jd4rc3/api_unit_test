using Productos.DTOs.Categorias;

namespace Productos.Services.Api
{
    public interface ICategoriaApi
    {
        Task<CategoriaDTO> ActualizarCategoriaPrueba(CrearCategoriaDTO categoriaDTO, int Id);

        Task<CategoriaDTO> Crear(CrearCategoriaDTO crearCategoriaDTO);

        Task<CategoriaDTO> Eliminar(int id);

        Task<CategoriaDTO> ObtenerCategoria(int id);

        Task<List<CategoriaDTO>> ObtenerCategorias();
    }
}