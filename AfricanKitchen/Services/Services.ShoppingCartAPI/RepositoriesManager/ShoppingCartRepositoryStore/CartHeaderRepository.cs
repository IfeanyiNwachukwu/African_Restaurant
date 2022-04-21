using Microsoft.EntityFrameworkCore;
using Services.ShoppingCartAPI.Contracts.IRepositoryManager.ShoppingCartRepositoryStore;
using Services.ShoppingCartAPI.DbContexts;
using Services.ShoppingCartAPI.Models;

namespace Services.ShoppingCartAPI.RepositoriesManager.ShoppingCartRepositoryStore
{
    public class CartHeaderRepository : RepositoryBase<CartHeader>, ICartHeaderRepository
    {
        public CartHeaderRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
        {

        }
        public void CreateUpdateCartHeader(CartHeader cartHeader)
        {
            if (cartHeader.CartHeaderId > 0)
            {
                Update(cartHeader);
            }
            else
            {
                Create(cartHeader);
            }
        }

        public async Task<bool> DeleteCartHeader(int cartHeaderId)
        {
            try
            {
                var cartHeaderToDelete = await FindByCondition(c => c.CartHeaderId == cartHeaderId).SingleOrDefaultAsync();
                if (cartHeaderToDelete == null)
                {
                    return false;
                }
                Delete(cartHeaderToDelete);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
            throw new NotImplementedException();
        }

        public async Task<CartHeader> GetCartHeaderById(int cartHeaderId) =>
             await FindByCondition(c => c.CartHeaderId == cartHeaderId)
            .SingleOrDefaultAsync();


        public async Task<IEnumerable<CartHeader>> GetCartHeaders() =>
        await FindAll()
         .OrderBy(c => c.CartHeaderId)
         .ToListAsync();
    }
}
