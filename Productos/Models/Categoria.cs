using System.ComponentModel.DataAnnotations;

namespace Productos.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        public string Categoria_nombre { get; set; }

        public List<Subcategoria> Subcategorias { get; set; }
    }
}