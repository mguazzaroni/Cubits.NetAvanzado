using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Cubits.NET.Avanzado.Application
{
    public static class Installers
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(conf => conf.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
