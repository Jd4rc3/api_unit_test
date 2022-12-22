using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Productos.Controllers;
using Productos.DTOs.Categorias;
using Productos.Services.Api;
using Productos.Utilities;
using webapi.Tests.Controllers.Helpers;

namespace WebApi.Test.Controllers
{
    public class CategoriaTest
    {
        private readonly MockRepository mockRepository;

        private readonly Mock<ICategoriaApi> mockService;

        private IMapper mapper;

        private IConfigurationProvider configuration;

        public CategoriaTest()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockService = this.mockRepository.Create<ICategoriaApi>();
            this.configuration = new MapperConfiguration(cfg => cfg.AddProfile<PerfilesAutoMapper>());
            this.mapper = this.configuration.CreateMapper();
        }

        [Fact]
        public async Task CrearCategoria()
        {
            var dto = It.IsAny<CrearCategoriaDTO>();

            mockService.Setup(x => x.Crear(dto)).ReturnsAsync(Build.Categoria());

            var controller = new CategoriaController(mockService.Object);

            var result = await controller.CrearCategoria(dto);

            var createdResult = result as CreatedResult;

            Assert.Equal(1, (createdResult.Value as CategoriaDTO).Id);
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public async Task ActualizarCategoria()
        {
            var dto = It.IsAny<CrearCategoriaDTO>();

            mockService.Setup(x => x.Actualizar(dto, 1)).ReturnsAsync(Build.Categoria());

            var controller = new CategoriaController(mockService.Object);

            var result = await controller.ActualizarCategoria(dto, 1);

            var okResult = result as OkObjectResult;

            Assert.Equal(1, (okResult.Value as CategoriaDTO).Id);
            Assert.Equal(200, okResult.StatusCode);
            Assert.IsType<OkObjectResult>(result);
        }

        public async Task ObtenerCategoria()
        {
            mockService.Setup(c => c.ObtenerCategoria(1)).ReturnsAsync(Build.Categoria());

            var controller = new CategoriaController(mockService.Object);

            var result = await controller.ObtenerCategoria(1);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task ObtenerCategorias()
        {
            mockService.Setup(c => c.ObtenerCategorias()).ReturnsAsync(Build.Categorias());

            var controller = new CategoriaController(mockService.Object);

            var result = await controller.ObtenerCategorias();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task EliminarCategoria()
        {
            mockService.Setup(c => c.Eliminar(1)).ReturnsAsync(Build.Categoria());

            var controller = new CategoriaController(mockService.Object);

            var result = await controller.EliminarCategoria(1);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}