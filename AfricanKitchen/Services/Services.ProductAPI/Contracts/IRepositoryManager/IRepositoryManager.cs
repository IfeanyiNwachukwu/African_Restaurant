using Services.ProductAPI.Contracts.IRepositoryManager.ProductRepositoryStore;

namespace Services.ProductAPI.Contracts.IRepositoryManager
{
    public interface IRepositoryManager
    {
        IProductRepository Product { get; }
        Task SaveAsync();
    }
}
