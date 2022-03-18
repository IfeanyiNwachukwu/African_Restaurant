using AfricanKitchen.Web.Helpers;
using AfricanKitchen.Web.Models;
using AfricanKitchen.Web.ServiceStore.IServices;

namespace AfricanKitchen.Web.ServiceStore.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _clientFactory;
        public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
        {

        }
        public async Task<T> CreateProductAsync<T>(ProductDTO model)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = model,
                Url = StaticDetails.ProductAPIBase + "/api/products",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.DELETE,
                Url = StaticDetails.ProductAPIBase + "/api/products/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.ProductAPIBase + "/api/products",
                AccessToken = ""
            });
        }

        public async Task<T> GetProductsByIdAsync<T>(int id)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.ProductAPIBase + $"/api/products/{id}",
                AccessToken = ""
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDTO model)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.PUT,
                Data = model ?? null,
                Url = StaticDetails.ProductAPIBase + "/api/products",
                AccessToken = ""
            });
        }
    }
}
