using AfricanKitchen.Web.Helpers;
using AfricanKitchen.Web.Models;
using AfricanKitchen.Web.ServiceStore.IServices;

namespace AfricanKitchen.Web.ServiceStore.Services
{
    public class CouponService : BaseService, ICouponService
    {
        private readonly IHttpClientFactory _clientFactory;
        public CouponService(IHttpClientFactory clientFactory):base(clientFactory)
        {
            _clientFactory = clientFactory ?? throw new ArgumentNullException( nameof( clientFactory ) );
        }
        public async Task<T> GetCoupon<T>(string couponCode, string token = null)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.CouponAPIBase + $"/api/coupon/{couponCode}",
                AccessToken = token
            });
        }
    }
}
