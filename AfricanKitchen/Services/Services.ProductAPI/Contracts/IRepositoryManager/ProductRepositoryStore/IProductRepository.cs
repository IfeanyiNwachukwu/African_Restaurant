using Services.ProductAPI.Models;

namespace Services.ProductAPI.Contracts.IRepositoryManager.ProductRepositoryStore
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int productId);
        void CreateUpdateProduct(Product productDto);
        Task<bool> DeleteProduct(int productId);
    }
}
