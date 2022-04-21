using Services.ShoppingCartAPI.Models;

namespace Services.ShoppingCartAPI.Contracts.IRepositoryManager.ShoppingCartRepositoryStore
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int productId);
        void CreateUpdateProduct(Product model);
        Task<bool> DeleteProduct(int productId);
    }
}
