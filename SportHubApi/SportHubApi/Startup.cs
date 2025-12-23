using MongoDB.Driver;
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


            services.AddSingleton<IMongoClient>(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var connectionString = configuration["MongoDb:ConnectionString"];
                return new MongoClient(connectionString);
            });

            services.AddScoped<IMongoDatabase>(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                var configuration = sp.GetRequiredService<IConfiguration>();
                var databaseName = configuration["MongoDb:Database"];
                return client.GetDatabase(databaseName);
            });

            services.AddDbRepositoryAdapter(Configuration.Get<DbRepositoryAdapterConfiguration>());

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
