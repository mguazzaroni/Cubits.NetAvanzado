namespace Cubits.NET.Avanzado.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? SerialCode { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }
    }
}
