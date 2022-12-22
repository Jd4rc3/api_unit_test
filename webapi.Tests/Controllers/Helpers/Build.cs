using Productos.DTOs.Categorias;
using Productos.DTOs.SubCategorias;

namespace webapi.Tests.Controllers.Helpers
{
    public static class Build
    {
        public static CategoriaDTO Categoria()
        {
            return new CategoriaBuilder().Categoria;
        }

        public static List<CategoriaDTO> Categorias()
        {
            return new CategoriaBuilder().Categorias;
        }
    }

    public class CategoriaBuilder
    {
        public CategoriaDTO Categoria { get; set; }

        public List<CategoriaDTO> Categorias { get; set; }

        public CategoriaBuilder()
        {
            Categoria = new CategoriaDTO
            {
                Categoria_nombre = "Categoria 1",
                Id = 1,
                Subcategorias = new List<SubCategoriaDTO>()
            };

            Categorias = GetCategorias();
        }

        private List<CategoriaDTO> GetCategorias()
        {
            return new List<CategoriaDTO>
            {
                new CategoriaDTO
                {
                    Id = 1,
                    Categoria_nombre = "Categoria 1"
                },
                new CategoriaDTO
                {
                    Id = 2,
                    Categoria_nombre = "Categoria 2"
                }
            };
        }
    }
}