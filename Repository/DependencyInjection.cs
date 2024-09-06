using Microsoft.Extensions.DependencyInjection;
using Repository.Implementations;
using Repository.Interface;

namespace Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddDbContext<IliaContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
