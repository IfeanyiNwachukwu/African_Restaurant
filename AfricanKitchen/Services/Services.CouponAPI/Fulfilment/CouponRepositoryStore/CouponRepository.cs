using Services.CouponAPI.Contracts.CouponRepositoryStore;
using Services.CouponAPI.DTOs;

namespace Services.CouponAPI.Fulfilment.CouponRepositoryStore
{
    public class CouponRepository : ICouponRepository
    {
        public Task<CouponDTO> GetCouponByCode(string couponCode)
        {
            throw new NotImplementedException();
        }
    }
}
