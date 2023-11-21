using Cubits.NET.Avanzado.Domain.Interfaces;
using Cubits.NET.Avanzado.Infastructure.Database;
using Cubits.NET.Avanzado.Infastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cubits.NET.Avanzado.Infastructure
{
    public static class Installer
    {
        public static void AddInfrastructure(this IServiceCollection serviceCollection, string? connectionString)
        {
            serviceCollection.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            serviceCollection.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
