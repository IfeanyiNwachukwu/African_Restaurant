using Services.CouponAPI.DTOs;

namespace Services.CouponAPI.Contracts.CouponRepositoryStore
{
    public interface ICouponRepository
    {
        Task<CouponDTO> GetCouponByCode(string couponCode);
    }
}
