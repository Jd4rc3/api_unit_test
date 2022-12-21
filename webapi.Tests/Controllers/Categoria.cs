﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Productos.Controllers;
using Productos.DTOs.Categorias;
using Productos.Services.Api;
using Productos.Utilities;

namespace WebApi.Test.Controllers
{
    public class Categoria
    {
        private readonly MockRepository mockRepository;

        private readonly Mock<ICategoriaApi> mockService;

        private IMapper mapper;

        private IConfigurationProvider configuration;

        public Categoria()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockService = this.mockRepository.Create<ICategoriaApi>();
            this.configuration = new MapperConfiguration(cfg => cfg.AddProfile<PerfilesAutoMapper>());
            this.mapper = this.configuration.CreateMapper();
        }

        [Fact]
        public async Task CrearCategoria()
        {
            var dto = new CrearCategoriaDTO
            {
                Categoria_nombre = "Categoria 1"
            };

            mockService.Setup(x => x.Crear(dto)).ReturnsAsync(new CategoriaDTO
            {
                Id = 1,
                Categoria_nombre = "Categoria 1"
            });

            var controller = new CategoriaController(mockService.Object);

            var result = await controller.CrearCategoria(dto);

            var createdResult = result as CreatedResult;

            Assert.Equal(1, (createdResult.Value as CategoriaDTO).Id);
            Assert.IsType<CreatedResult>(result);
        }
    }
}
