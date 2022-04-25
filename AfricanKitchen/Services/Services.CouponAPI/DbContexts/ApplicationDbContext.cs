using Microsoft.EntityFrameworkCore;
using Services.CouponAPI.Configuration;
using Services.CouponAPI.Models;

namespace Services.CouponAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
         
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CouponConfiguration());
        }
        public DbSet<Coupon> Coupons { get; set; }
    }
}

