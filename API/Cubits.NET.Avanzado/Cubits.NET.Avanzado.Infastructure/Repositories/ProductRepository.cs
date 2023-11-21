using Cubits.NET.Avanzado.Domain.Entities;
using Cubits.NET.Avanzado.Domain.Interfaces;
using Cubits.NET.Avanzado.Infastructure.Database;

namespace Cubits.NET.Avanzado.Infastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly DatabaseContext _context;

        public ProductRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Create(Product product)
        {
            _context.Set<Product>().Add(product);
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public Product? Get(int id)
        {
            var user = _context.Set<Product>().Where(user => user.Id == id).FirstOrDefault();

            return user;
        }

        public List<Product>? GetList()
        {
            return _context.Set<Product>().ToList();
        }

        public Product Update()
        {
            throw new NotImplementedException();
        }
    }
}
