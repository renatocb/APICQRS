using CQRS.Domain.Interfaces;
using CQRS.Infrastructure.Context;
using CQRS.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.CrossCutting
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            opt.UseInMemoryDatabase("InMem"));
            services.AddScoped<IZapImoveisRepository, ZapImoveisRepository>();            
            services.AddScoped<IVivaRealImoveisRepository, VivaRealImoveisRepository>();
            return services;
        }
    }
}
