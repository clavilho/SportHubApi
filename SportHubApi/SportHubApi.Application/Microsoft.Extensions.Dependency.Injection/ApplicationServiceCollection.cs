using Microsoft.Extensions.DependencyInjection;
using SportHubApi.Application.Services;
using SportHubApi.Domain.Services;

namespace SportHubApi.Application.Microsoft.Extensions.Dependency.Injection
{
    public static class ApplicationServiceCollection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, ApplicationConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSingleton(configuration);

            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
