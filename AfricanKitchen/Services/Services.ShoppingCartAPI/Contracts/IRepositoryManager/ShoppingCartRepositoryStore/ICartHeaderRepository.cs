using Services.ShoppingCartAPI.Models;

namespace Services.ShoppingCartAPI.Contracts.IRepositoryManager.ShoppingCartRepositoryStore
{
    public interface ICartHeaderRepository
    {
        Task<IEnumerable<CartHeader>> GetCartHeaders();
        Task<CartHeader> GetCartHeaderById(int cartHeaderId);
        void CreateUpdateCartHeader(CartHeader cartHeader);
        Task<bool> DeleteCartHeader(int productId);
    }
}
