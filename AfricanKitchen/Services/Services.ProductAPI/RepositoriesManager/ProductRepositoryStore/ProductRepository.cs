using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.ProductAPI.Contracts.IRepositoryManager.ProductRepositoryStore;
using Services.ProductAPI.DbContexts;
using Services.ProductAPI.Models;

namespace Services.ProductAPI.RepositoriesManager.ProductRepositoryStore
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
        {

        }
        public void CreateUpdateProduct([FromBody] Product product)
        {
            if (product.ProductId > 0)
            {
                Update(product);
            }
            else
            {
                Create(product);
            }
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                var productToDelete = await FindByCondition(p => p.ProductId == productId).SingleOrDefaultAsync();
                if (productToDelete == null)
                {
                    return false;
                }
                Delete(productToDelete);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<Product> GetProductById(int productId) =>
            await FindByCondition(p => p.ProductId == productId)
            .SingleOrDefaultAsync();



        public async Task<IEnumerable<Product>> GetProducts() =>
         await FindAll()
         .OrderBy(p => p.ProductId)
         .ToListAsync();
    }
}
