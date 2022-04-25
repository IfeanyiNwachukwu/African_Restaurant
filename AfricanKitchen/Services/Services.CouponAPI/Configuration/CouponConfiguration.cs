using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Services.CouponAPI.Models;

namespace Services.CouponAPI.Configuration
{
    public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.HasData(
                new Coupon
                {
                    CouponId = 1,
                    CouponCode = "10OFF",
                    DiscountAmount = 10
                },
                new Coupon
                {
                    CouponId = 2,
                    CouponCode = "10OFF",
                    DiscountAmount = 15
                },
                 new Coupon
                 {
                     CouponId = 3,
                     CouponCode = "20OFF",
                     DiscountAmount = 20
                 },
                 new Coupon
                 {
                     CouponId = 4,
                     CouponCode = "20OFF",
                     DiscountAmount = 20
                  },
                 new Coupon
                 {
                    CouponId = 5,
                    CouponCode = "22OFF",
                    DiscountAmount = 22
                 },
                 new Coupon
                 {
                    CouponId = 6,
                    CouponCode = "23OFF",
                    DiscountAmount = 23
                  }
             );
        }
    }
}
