using Cubits.NET.Avanzado.Domain.Entities;

namespace Cubits.NET.Avanzado.Domain.Interfaces
{
    public interface IProductRepository
    {
        List<Product>? GetList();

        Product? Get(int id);

        void Create(Product user);

        Product Update();

        void Delete();
    }
}
