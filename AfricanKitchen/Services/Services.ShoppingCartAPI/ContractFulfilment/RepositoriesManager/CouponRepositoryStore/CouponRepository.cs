using Newtonsoft.Json;
using Services.ShoppingCartAPI.Contracts.IRepositoryManager.CouponRepositoryStore;
using Services.ShoppingCartAPI.DataTransferObjects.Readable;
using Services.ShoppingCartAPI.Helpers;

namespace Services.ShoppingCartAPI.ContractFulfilment.RepositoriesManager.CouponRepositoryStore
{
    public class CouponRepository : ICouponRepository
    {
        private readonly HttpClient _client;
        public CouponRepository(HttpClient client)
        {
            _client = client;
        }
        public async Task<CouponDTO> GetCoupon(string couponName)
        {
            var response = await _client.GetAsync($"api/coupon/{couponName}");
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);
            if (resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<CouponDTO>(Convert.ToString(resp.Result));
            }
            return new CouponDTO();
          
        }
    }
}
