using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.OrderAPI.DbContexts;
using Services.OrderAPI.Fulfilment.OrderRepositoryStore;

namespace Services.OrderAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
      services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        public static void ConfigureAuthentication(this IServiceCollection services) =>
            services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.Authority = "https://localhost:44315/";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false
                };
            });

        public static void ConfigureAuthorization(this IServiceCollection services) =>
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "africanKitchen");
                });
            });

        public static void ConfigureSwaggerGen(this IServiceCollection services) =>
             services.AddSwaggerGen(c =>
             {
                 c.SwaggerDoc("v1", new OpenApiInfo { Title = "AfricanKitchen.Services.OrderAPI", Version = "v1" });
                 c.EnableAnnotations();
                 c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                 {
                     Description = @"Enter 'Bearer' [space] and your token",
                     Name = "Authorization",
                     In = ParameterLocation.Header,
                     Type = SecuritySchemeType.ApiKey,
                     Scheme = "Bearer"
                 });

                 c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            },
                            Scheme="oauth2",
                            Name="Bearer",
                            In=ParameterLocation.Header
                        },
                        new List<string>()
                    }

                });
             });

        public static void ConfigureSingletonOrderRepository(this IServiceCollection services, IConfiguration configuration)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            services.AddSingleton(new OrderRepository(optionBuilder.Options));
        }
    }
}
