using Microsoft.Extensions.DependencyInjection;
using Services.Implementations;
using Services.Interface;

namespace Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}
