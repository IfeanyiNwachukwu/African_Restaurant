using Services.ProductAPI.Contracts.IRepositoryManager;
using Services.ProductAPI.Contracts.IRepositoryManager.ProductRepositoryStore;
using Services.ProductAPI.DbContexts;
using Services.ProductAPI.RepositoriesManager.ProductRepositoryStore;

namespace Services.ProductAPI.RepositoriesManager
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
                if( _productRepository == null)
                {
                    _productRepository = new ProductRepository(_repositoryContext);
                }
                return _productRepository;
            }
        }

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
