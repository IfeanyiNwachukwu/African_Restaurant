using Microsoft.EntityFrameworkCore;
using Services.ProductAPI.DbContexts;

namespace Services.ProductAPI.Extensions
{
    public static class ServicesExtension
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
          services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}
