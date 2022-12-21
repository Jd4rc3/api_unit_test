using Microsoft.AspNetCore.Mvc;
using Productos.DTOs.SubCategorias;
using Productos.Services.Api;
using System.Net.Mime;

namespace Productos.Controllers
{
    [ApiController]
    [Route("api/v1/subcategory")]
    public class SubCategoriaController : ControllerBase
    {
        private readonly ISubCategoriaApi subCategoriaApi;

        public SubCategoriaController(ISubCategoriaApi subCategoria)
        {
            this.subCategoriaApi = subCategoria;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> CrearSubCategoria([FromBody] CrearSubCategoriaDTO crearSubCategoria)
        {
            var subCategoria = await subCategoriaApi.Crear(crearSubCategoria);

            return Created("", subCategoria);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarSubCategoria([FromRoute] int id)
        {
            var subCategoria = await subCategoriaApi.Eliminar(id);

            return Ok(subCategoria);
        }

        [HttpGet]
        public async Task<ActionResult> ObtenerSubCategorias()
        {
            var subCategorias = await subCategoriaApi.ObtenerSubCategorias();

            return Ok(subCategorias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ObtenerSubCategoria([FromRoute] int id)
        {
            var subCategoria = await subCategoriaApi.ObtenerSubCategoria(id);

            return Ok(subCategoria);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarSubCategoria([FromBody] CrearSubCategoriaDTO dto, [FromRoute] int id)
        {
            var subCategoria = await subCategoriaApi.Actualizar(dto, id);

            return Ok(subCategoria);
        }
    }
}
