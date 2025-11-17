using Microsoft.Extensions.Configuration;
using SportHubApi.DbRepository;
using SportHubApi.DbRepository.Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace SportHubApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddControllers();
            services.AddMvc().AddJsonOptions(options => options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault);
            services.AddHealthChecks();
            services.AddEndpointsApiExplorer();

            services.AddDbRepositoryAdapter(Configuration.Get<DbRepositoryAdapterConfiguration>());
        }
    }
}
