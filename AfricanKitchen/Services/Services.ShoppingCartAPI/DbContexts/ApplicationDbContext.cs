using Microsoft.EntityFrameworkCore;

namespace Services.ShoppingCartAPI.DbContexts
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
        //public DbSet<Product> Products { get; set; }
    }
}
