using Duende.IdentityServer.AspNetIdentity;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Identity.DbContexts;
using Services.Identity.Helpers;
using Services.Identity.Initializer.Contracts;
using Services.Identity.Initializer.ContractsFulfilment;
using Services.Identity.Models;
using Services.Identity.Services;

namespace Services.Identity.Extension
{
    public static class ServicesExtension
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        public static void ConfigureIdentity(this IServiceCollection services) =>
            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders(); // Token providers are used when you forget your password

        public static void ConfigureIdentityServer(this IServiceCollection services)
        {
            var builder = services.AddIdentityServer(options =>
           {
               options.Events.RaiseErrorEvents = true;
               options.Events.RaiseInformationEvents = true;
               options.Events.RaiseFailureEvents = true;
               options.Events.RaiseSuccessEvents = true;
               options.EmitStaticAudienceClaim = true;
           }).AddInMemoryIdentityResources(StaticDetails.IdentityResources)
             .AddInMemoryApiScopes(StaticDetails.ApiScopes)
             .AddInMemoryClients(StaticDetails.Clients)
             .AddAspNetIdentity<ApplicationUser>();

            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddScoped<IProfileService, ProfileService>();
           
            builder.AddDeveloperSigningCredential(); // Automatically generates a key and adds it only for development purposes
        

        }

     

    }
}
