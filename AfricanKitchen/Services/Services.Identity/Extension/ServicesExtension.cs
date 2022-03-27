using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Identity.DbContexts;
using Services.Identity.Helpers;
using Services.Identity.Initializer.Contracts;
using Services.Identity.Models;

namespace Services.Identity.Extension
{
    public static class ServicesExtension
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        public static void ConfigureIdentity(this IServiceCollection services) =>
            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

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

            builder.AddDeveloperSigningCredential();
        

        }

     

    }
}
