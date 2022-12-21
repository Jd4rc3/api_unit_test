using Productos.DTOs.SubCategorias;

namespace Productos.DTOs.Categorias
{
    public class CategoriaDTO
    {
        public int Id { get; set; }

        public string Categoria_nombre { get; set; }

        public List<SubCategoriaDTO> Subcategorias { get; set; }
    }
}