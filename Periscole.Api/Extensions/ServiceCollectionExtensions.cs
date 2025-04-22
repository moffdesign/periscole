using Microsoft.Extensions.DependencyInjection;

namespace Periscole.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RepositoryRegisterService(this IServiceCollection services)
        {
            // Register your repositories here, for example:
            // services.AddScoped<IYourRepository, YourRepositoryImplementation>();
            return services;
        }
    }
}
