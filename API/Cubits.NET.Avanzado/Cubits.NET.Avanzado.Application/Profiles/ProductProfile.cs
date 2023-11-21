using AutoMapper;
using Cubits.NET.Avanzado.Application.Models;
using Cubits.NET.Avanzado.Domain.Entities;

namespace Cubits.NET.Avanzado.Application.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
