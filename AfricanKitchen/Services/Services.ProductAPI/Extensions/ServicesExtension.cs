﻿using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.ProductAPI.Contracts.IRepositoryManager;
using Services.ProductAPI.DbContexts;
using Services.ProductAPI.RepositoriesManager;

namespace Services.ProductAPI.Extensions
{
    public static class ServicesExtension
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
          services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
          services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureAuthentication(this IServiceCollection services) =>
            services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
             {
                 options.Authority = "https://localhost:7046/";
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
                 c.SwaggerDoc("v1", new OpenApiInfo { Title = "AfricanKitchen.Services.ProductAPI", Version = "v1" });
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


    }

}

