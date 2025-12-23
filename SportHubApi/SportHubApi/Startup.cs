using MongoDB.Driver;
using SportHubApi.Application;
using SportHubApi.Application.Microsoft.Extensions.Dependency.Injection;
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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddControllers();

            services.AddMvc()
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.DefaultIgnoreCondition =
                        JsonIgnoreCondition.WhenWritingDefault);

            services.AddHealthChecks();
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();


            //services.Configure<DbRepositoryAdapterConfiguration>(
            //Configuration.GetSection("DbRepositoryAdapterConfiguration"));

            services.AddDbRepositoryAdapter(Configuration.GetSection("DbRepositoryAdapterConfiguration").Get<DbRepositoryAdapterConfiguration>());
            services.AddApplication(Configuration.Get<ApplicationConfiguration>());

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SportHub API v1");
                    c.RoutePrefix = "swagger";
                });
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
