using AutoMapper;
using Cubits.NET.Avanzado.Application.Contracts;
using Cubits.NET.Avanzado.Application.Handlers;
using Cubits.NET.Avanzado.Application.Models;
using Cubits.NET.Avanzado.Domain.Entities;
using Cubits.NET.Avanzado.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Xunit;

namespace Cubits.NET.Avanzado.Test
{
    public class GetProductListHandlerTest
    {
        private readonly Mock<IProductRepository> _productRepository;
        private readonly Mock<IValidator<GetProductListRequest>> _validator;
        private readonly Mock<IMapper> _mapper;

        private GetProductListHandler handler;

        public GetProductListHandlerTest()
        {
            _mapper = new Mock<IMapper>();
            _mapper
                .Setup(m => m.Map<ProductDto>(It.IsAny<Product>()))
                .Returns(MockProductDto());

            var result = new ValidationResult();
            _validator = new Mock<IValidator<GetProductListRequest>>();
            _validator
                .Setup(v => v.Validate(It.IsAny<GetProductListRequest>()))
                .Returns(result);

            _productRepository = new Mock<IProductRepository>();
            _productRepository
                .Setup(r => r.GetList())
                .Returns(MockProductList());

            handler = new GetProductListHandler(
                _productRepository.Object,
                _validator.Object,
                _mapper.Object);
        }

        [Fact]
        public async void SiObtengoRequestValido_RetornoResponseValido()
        {
            // Arrange

            // Act
            var response = await handler.Handle(new GetProductListRequest(), CancellationToken.None);

            // Assert
            Assert.NotNull(response);
            Assert.NotNull(response.ProductList);
        }

        private List<Product> MockProductList()
        {
            return new List<Product>
            {
                new Product
                {
                    Name = "Product1",
                    Price = 10,
                    Stock = 20,
                },
                new Product
                {
                    Name = "Product2",
                    Price = 10,
                    Stock = 20,
                },
            };
        }

        private ProductDto MockProductDto()
        {
            return new ProductDto
            {
                Name = "ProductDto1",
                Price = 10,
                Stock = 20,
            };
        }
    }
}
