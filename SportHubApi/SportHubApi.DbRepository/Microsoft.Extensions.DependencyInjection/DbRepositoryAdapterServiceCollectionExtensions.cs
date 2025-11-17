using Microsoft.Extensions.DependencyInjection;
using SportHubApi.Domain.Adapters;

namespace SportHubApi.DbRepository.Microsoft.Extensions.DependencyInjection
{
    public static class DbRepositoryAdapterServiceCollectionExtensions
    {
        public static IServiceCollection AddDbRepositoryAdapter(
           this IServiceCollection services,
           DbRepositoryAdapterConfiguration dbRepositoryAdapter)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (dbRepositoryAdapter is null)
            {
                throw new ArgumentException(nameof(dbRepositoryAdapter));
            }

            services.AddSingleton(dbRepositoryAdapter);

            services.AddScoped<IDbRepositoryAdapter, DbRepositoryAdapter>();

            return services;
        }
    }
}
