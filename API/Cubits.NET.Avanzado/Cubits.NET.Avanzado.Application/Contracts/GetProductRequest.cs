using MediatR;

namespace Cubits.NET.Avanzado.Application.Contracts
{
    public class GetProductRequest : IRequest<GetProductResponse>
    {
        public int Id { get; set; }
    }
}
