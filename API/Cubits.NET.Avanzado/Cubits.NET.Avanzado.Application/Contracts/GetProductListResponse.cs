using Cubits.NET.Avanzado.Application.Models;

namespace Cubits.NET.Avanzado.Application.Contracts
{
    public class GetProductListResponse
    {
        public List<ProductDto>? ProductList { get; set; }
    }
}
