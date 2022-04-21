using Services.ShoppingCartAPI.Contracts.IRepositoryManager;
using Services.ShoppingCartAPI.Contracts.IRepositoryManager.ShoppingCartRepositoryStore;
using Services.ShoppingCartAPI.DbContexts;
using Services.ShoppingCartAPI.RepositoriesManager.ShoppingCartRepositoryStore;

namespace Services.ShoppingCartAPI.RepositoriesManager
{
    public class RepositoryManager : IRepositoryManager
    {
        private ApplicationDbContext _repositoryContext;
        private IProductRepository _productRepository;

        public RepositoryManager(ApplicationDbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IProductRepository Product
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_repositoryContext);
                }
                return _productRepository;
            }
        }

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
