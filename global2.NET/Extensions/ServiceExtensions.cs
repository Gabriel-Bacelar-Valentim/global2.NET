using global2.NET.Configuration;
using global2.NET.Database;
using global2.NET.Database.Models;
using global2.NET.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace global2.NET.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Address>, Repository<Address>>();
            services.AddScoped<IRepository<ContactNumber>, Repository<ContactNumber>>();
            services.AddScoped<IRepository<Device>, Repository<Device>>();
            services.AddScoped<IRepository<EnergyLecture>, Repository<EnergyLecture>>();
            services.AddScoped<IRepository<IncentiveScore>, Repository<IncentiveScore>>();
            services.AddScoped<IRepository<OptimizationAlert>, Repository<OptimizationAlert>>();
            services.AddScoped<IRepository<PrincipalUser>, Repository<PrincipalUser>>();

            return services;
        }

        public static IServiceCollection AddContext(this IServiceCollection services, APIConfiguration apiConfiguration)
        {
            // Oracle
            services.AddDbContext<FIAPDbContext>(options =>
            {
                options.UseOracle(apiConfiguration.OracleFIAP.ConnectionString);
            });

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services, APIConfiguration apiConfiguration)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = $"{apiConfiguration.Swagger.Title} {DateTime.Now.Year} ",
                    Version = "v1",
                    Description = apiConfiguration.Swagger.Description,
                    Contact = new OpenApiContact() { Name = apiConfiguration.Swagger.Name, Email = apiConfiguration.Swagger.Email }
                });
                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            return services;
        }
    }
}
