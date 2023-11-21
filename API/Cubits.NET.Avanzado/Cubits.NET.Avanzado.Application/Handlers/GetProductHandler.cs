using AutoMapper;
using Cubits.NET.Avanzado.Application.Contracts;
using Cubits.NET.Avanzado.Application.Models;
using Cubits.NET.Avanzado.Domain.Entities;
using Cubits.NET.Avanzado.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace Cubits.NET.Avanzado.Application.Handlers
{
    public class GetProductHandler : IRequestHandler<GetProductRequest, GetProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IValidator<GetProductRequest> _validator;
        private readonly IMapper _mapper;

        public GetProductHandler(
            IProductRepository productRepository,
            IValidator<GetProductRequest> validator,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<GetProductResponse> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var response = new GetProductResponse();

            if (!_validator.Validate(request).IsValid)
            {
                throw new HttpRequestException();
            }

            var product = _productRepository.Get(request.Id);

            response.Product = MapTo(product);
            
            return response;
        }

        private ProductDto MapTo(Product product)
        {
            return _mapper.Map<ProductDto>(product);
        }
    }
}
