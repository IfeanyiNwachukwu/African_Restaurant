using AfricanChicken.Web.Models;

namespace AfricanChicken.Web.ServiceStore.IServices
{
    public interface IProductService
    {
        Task<T> GetAllProductsAsync<T>();
        Task<T> GetProductsByIdAsync<T>(int id);
        Task<T> CreateProductAsync<T>(ProductDTO model);
        Task<T> UpdateProductAsync<T>(ProductDTO model);
        Task<T> DeleteProductAsync<T>(int id);
    }
}
