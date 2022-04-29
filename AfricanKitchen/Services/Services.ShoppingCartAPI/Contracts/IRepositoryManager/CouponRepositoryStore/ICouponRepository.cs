using Services.ShoppingCartAPI.DataTransferObjects.Readable;

namespace Services.ShoppingCartAPI.Contracts.IRepositoryManager.CouponRepositoryStore
{
    public interface ICouponRepository
    {
        Task<CouponDTO> GetCoupon(string couponName);
    }
}
