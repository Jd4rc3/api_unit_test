
using Microsoft.AspNetCore.Mvc;
using Productos.DTOs.Categorias;
using Productos.Services.Api;

namespace Productos.Controllers
{
    [ApiController]
    [Route("api/v1/category")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaApi categoriaApi;

        public CategoriaController(ICategoriaApi categoria)
        {
            this.categoriaApi = categoria;
        }

        [HttpPost]
        public async Task<ActionResult> CrearCategoria([FromBody] CrearCategoriaDTO crearCategoria)
        {
            var categoria = await categoriaApi.Crear(crearCategoria);

            return Ok(categoria);
        }

    }
}
