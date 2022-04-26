namespace AfricanKitchen.Web.ServiceStore.IServices
{
    public interface ICouponService
    {
        Task<T> GetCoupon<T>(string userId, string token = null);
    }
}
