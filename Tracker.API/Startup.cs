using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Tracker.Repository;
using Tracker.Services;

namespace Tracker.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Change feed", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,

                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            services.AddAutoMapper(typeof(AutoMapping));

            services.AddSingleton<ProductContext>(k =>
            {
                var endPoint = Configuration["CosmosSql:CosmosEndpoint"];
                var key = Configuration["CosmosSql:CosmosKey"];
                var databaseName = Configuration["CosmosSql:CosmosDatabaseId"];
                var collectionName = Configuration["CosmosSql:CosmosProductCollection"];

                return new ProductContext(endPoint, key, databaseName, collectionName);
            });

            services.AddSingleton<CustomerContext>(k =>
            {
                var endPoint = Configuration["CosmosSql:CosmosEndpoint"];
                var key = Configuration["CosmosSql:CosmosKey"];
                var databaseName = Configuration["CosmosSql:CosmosDatabaseId"];
                var collectionName = Configuration["CosmosSql:CosmosCustomerCollection"];

                return new CustomerContext(endPoint, key, databaseName, collectionName);
            });

            services.AddSingleton<OrderContext>(k =>
            {
                var endPoint = Configuration["CosmosSql:CosmosEndpoint"];
                var key = Configuration["CosmosSql:CosmosKey"];
                var databaseName = Configuration["CosmosSql:CosmosDatabaseId"];
                var collectionName = Configuration["CosmosSql:CosmosOrderCollection"];

                return new OrderContext(endPoint, key, databaseName, collectionName);
            });

            new ServiceModule(services);
            new RepositoryModule(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Change feed");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
