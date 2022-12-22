using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Productos.Controllers;
using Productos.DTOs.SubCategorias;
using Productos.Services.Api;
using Productos.Utilities;

namespace webapi.Tests.Controllers
{
    public class SubCategoria
    {
        private readonly MockRepository mockRepository;

        private readonly Mock<ISubCategoriaApi> mockService;

        private IMapper mapper;

        private IConfigurationProvider configuration;

        public SubCategoria()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockService = this.mockRepository.Create<ISubCategoriaApi>();
            this.configuration = new MapperConfiguration(cfg => cfg.AddProfile<PerfilesAutoMapper>());
            this.mapper = this.configuration.CreateMapper();
        }

        [Fact]
        public async Task CrearSubCategoria()
        {
            var dto = It.IsAny<CrearSubCategoriaDTO>();

            mockService.Setup(x => x.Crear(dto)).ReturnsAsync(new SubCategoriaDTO
            {
                Id = 1,
                Subcategoria_nombre = "SubCategoria 1"
            });

            var controller = new SubCategoriaController(mockService.Object);

            var result = await controller.CrearSubCategoria(dto);

            var createdResult = result as CreatedResult;

            Assert.Equal(1, (createdResult.Value as SubCategoriaDTO).Id);
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public async Task ActualizaSubCategoria()
        {
            var dto = new CrearSubCategoriaDTO
            {
                Subcategoria_nombre = "SubCategoria 1"
            };

            mockService.Setup(x => x.Actualizar(dto, 1)).ReturnsAsync(new SubCategoriaDTO
            {
                Id = 1,
                Subcategoria_nombre = "SubCategoria 1",
            });

            var controller = new SubCategoriaController(mockService.Object);

            var result = await controller.ActualizarSubCategoria(dto, 1);

            var okResult = result as OkObjectResult;

            Assert.Equal(1, (okResult.Value as SubCategoriaDTO).Id);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task ObtenerSubCategoria()
        {
            mockService.Setup(x => x.ObtenerSubCategoria(1)).ReturnsAsync(new SubCategoriaDTO
            {
                Id = 1,
                Subcategoria_nombre = "SubCategoria 1",
            });

            var controller = new SubCategoriaController(mockService.Object);

            var result = await controller.ObtenerSubCategoria(1);

            var okResult = result as OkObjectResult;

            Assert.Equal(1, (okResult.Value as SubCategoriaDTO).Id);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task ObtenerSubCategorias()
        {
            mockService.Setup(x => x.ObtenerSubCategorias()).ReturnsAsync(new List<SubCategoriaDTO>
            {
                new SubCategoriaDTO
                {
                    Id = 1,
                    Subcategoria_nombre = "SubCategoria 1",
                },
                new SubCategoriaDTO
                {
                    Id = 2,
                    Subcategoria_nombre = "SubCategoria 2",
                }
            });

            var controller = new SubCategoriaController(mockService.Object);

            var result = await controller.ObtenerSubCategorias();

            var okResult = result as OkObjectResult;

            Assert.Equal(2, (okResult.Value as List<SubCategoriaDTO>).Count);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task EliminarSubCategoria()
        {
            mockService.Setup(x => x.Eliminar(1)).ReturnsAsync(It.IsAny<SubCategoriaDTO>());

            var controller = new SubCategoriaController(mockService.Object);

            var result = await controller.EliminarSubCategoria(1);

            var okResult = result as OkObjectResult;

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
