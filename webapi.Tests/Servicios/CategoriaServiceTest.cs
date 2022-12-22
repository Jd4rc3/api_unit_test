using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using Productos;
using Productos.DTOs.Categorias;
using Productos.Models;
using Productos.Services;
using Productos.Utilities;

namespace webapi.Tests.Servicios
{
    public class CategoriaServiceTest
    {
        private readonly List<Categoria> _categorias = new List<Categoria>
        {
            new Categoria{ Id = 1,Categoria_nombre="Categoria #1"},
            new Categoria{ Id = 2,Categoria_nombre="Categoria #2"},
        };

        private IMapper mapper;

        private readonly Mock<DbSet<Categoria>> mockCategoria;

        private readonly Mock<Contexto> mockContexto;
        private IConfigurationProvider configuration;

        public CategoriaServiceTest()
        {
            mockContexto = new Mock<Contexto>();
            mockCategoria = _categorias.AsQueryable().BuildMockDbSet();
            this.configuration = new MapperConfiguration(cfg => cfg.AddProfile<PerfilesAutoMapper>());
            this.mapper = this.configuration.CreateMapper();
        }

        [Fact]
        public async Task CrearCategoriaTest()
        {
            mockContexto.Setup(c => c.Categorias).Returns(mockCategoria.Object);

            var servicio = new CategoriaService(mockContexto.Object, mapper);

            var dto = new CrearCategoriaDTO { Categoria_nombre = "Categoria # 1" };
            var result = await servicio.Crear(dto);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ActualizarCategoriaTestOk()
        {
            mockContexto.Setup(c => c.Categorias).Returns(mockCategoria.Object);
            var servicio = new CategoriaService(mockContexto.Object, mapper);
            var dto = new CrearCategoriaDTO { Categoria_nombre = "Categoria Actulaizar" };

            var result = await servicio.Actualizar(dto, 1);

            Assert.Equal(dto.Categoria_nombre, result.Categoria_nombre);
        }

        [Fact]
        public async Task ActualizarCategoriaNull()
        {
            mockContexto.Setup(c => c.Categorias).Returns(mockCategoria.Object);
            var servicio = new CategoriaService(mockContexto.Object, mapper);
            var dto = new CrearCategoriaDTO { Categoria_nombre = "Categoria Actulaizar" };

            var result = await servicio.Actualizar(dto, 10);

            Assert.Null(result);
        }
    }
}