using Microsoft.Extensions.DependencyInjection;
using WorldCup.ApplicationService.Services;

namespace WorldCup.ApplicationService.DI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServiceModule(this IServiceCollection services)
        {
            services.AddTransient<IGenerateDrawService, GenerateDrawService>();

            return services;
        }
    }
}
