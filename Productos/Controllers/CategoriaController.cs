using Microsoft.AspNetCore.Mvc;
using Productos.DTOs.Categorias;
using Productos.Services.Api;
using System.Net.Mime;

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
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> CrearCategoria([FromBody] CrearCategoriaDTO crearCategoria)
        {
            var categoria = await categoriaApi.Crear(crearCategoria);

            return Created("", categoria);
        }

        [HttpPut("{id:int}")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> ActualizarCategoria([FromBody] CrearCategoriaDTO categoria, [FromRoute] int id)
        {
            var categoriaActualizada = await categoriaApi.Actualizar(categoria, id);

            return Ok(categoriaActualizada);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> EliminarCategoria(int id)
        {
            var categoria = await categoriaApi.Eliminar(id);

            return Ok(categoria);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> ObtenerCategoria(int id)
        {
            var categoria = await categoriaApi.ObtenerCategoria(id);

            return Ok(categoria);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> ObtenerCategorias()
        {
            var categorias = await categoriaApi.ObtenerCategorias();

            return Ok(categorias);
        }
    }
}