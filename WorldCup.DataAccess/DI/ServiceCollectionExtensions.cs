using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WorldCup.DataAccess.Repositories;

namespace WorldCup.DataAccess.DI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccessModule(this IServiceCollection services)
        {
            services.AddDbContext<WorldCupDbContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
            services.AddScoped<WorldCupDbUoW>();
            return services;
        }
    }
}
