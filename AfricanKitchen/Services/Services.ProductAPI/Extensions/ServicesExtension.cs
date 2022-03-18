using Microsoft.EntityFrameworkCore;
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


    }
}
