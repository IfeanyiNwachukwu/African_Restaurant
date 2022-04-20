using AfricanKitchen.Web.Models;

namespace AfricanKitchen.Web.ServiceStore.IServices
{
    public interface IProductService
    {
        Task<T> GetAllProductsAsync<T>(string token);
        Task<T> GetProductsByIdAsync<T>(int id, string token);
        Task<T> CreateProductAsync<T>(ProductDTO model, string token);
        Task<T> UpdateProductAsync<T>(ProductDTO model, string token);
        Task<T> DeleteProductAsync<T>(int id, string token);
    }
}
