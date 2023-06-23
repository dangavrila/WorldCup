using Microsoft.Extensions.DependencyInjection;
using WorldCup.ApplicationService.Services;
using WorldCup.DataAccess.DI;

namespace WorldCup.ApplicationService.DI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServiceModule(this IServiceCollection services)
        {
            services.AddDataAccessModule();
            services.AddTransient<IGenerateDrawService, GenerateDrawService>();
            services.AddTransient<IQueryLeageGroupsService, QueryLeageGroupsService>();

            return services;
        }
    }
}
