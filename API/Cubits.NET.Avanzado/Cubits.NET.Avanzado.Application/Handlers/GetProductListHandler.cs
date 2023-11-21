using AutoMapper;
using Cubits.NET.Avanzado.Application.Contracts;
using Cubits.NET.Avanzado.Application.Models;
using Cubits.NET.Avanzado.Domain.Entities;
using Cubits.NET.Avanzado.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace Cubits.NET.Avanzado.Application.Handlers
{
    public class GetProductListHandler : IRequestHandler<GetProductListRequest, GetProductListResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IValidator<GetProductListRequest> _validator;
        private readonly IMapper _mapper;

        public GetProductListHandler(
            IProductRepository productRepository,
            IValidator<GetProductListRequest> validator,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<GetProductListResponse> Handle(GetProductListRequest request, CancellationToken cancellationToken)
        {
            var response = new GetProductListResponse();

            if (!_validator.Validate(request).IsValid)
            {
                throw new HttpRequestException();
            }

            var productList = _productRepository.GetList();

            if (request.Count > 0)
            {
                productList = productList?.OrderBy(o => o.Id).Take(request.Count).ToList();
            }


            response.ProductList = productList?.Select(MapTo).ToList();

            return response;
        }

        private ProductDto MapTo(Product product)
        {
            return _mapper.Map<ProductDto>(product);
        }
    }
}
