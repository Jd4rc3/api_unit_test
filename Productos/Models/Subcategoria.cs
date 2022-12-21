using System.ComponentModel.DataAnnotations;

namespace Productos.Models
{
    public class Subcategoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [StringLength(maximumLength: 150, MinimumLength = 3, ErrorMessage = "{0} minimo {2} maximo {1} caractertes")]
        public string Subcategoria_nombre { get; set; }

        [Required]
        public int Categoria_id { get; set; }

        public Categoria Categoria { get; set; }
    }
}