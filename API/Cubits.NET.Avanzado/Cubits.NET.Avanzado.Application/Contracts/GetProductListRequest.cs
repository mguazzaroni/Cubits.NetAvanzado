using MediatR;

namespace Cubits.NET.Avanzado.Application.Contracts
{
    // INPUT del Handler
    public class GetProductListRequest : IRequest<GetProductListResponse>
    {
        public int Count { get; set; }
    }
}
