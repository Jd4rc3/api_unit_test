using System.ComponentModel.DataAnnotations;

namespace Productos.DTOs.Categorias
{
    public class CrearCategoriaDTO
    {
        [Required(ErrorMessage = "{0} es requerido")]
        [StringLength(maximumLength: 150, MinimumLength = 3, ErrorMessage = "{0} minimo {2} maximo {1} caractertes")]
        public string Categoria_nombre { get; set; }
    }
}