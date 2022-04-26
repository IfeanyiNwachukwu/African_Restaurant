using Services.ShoppingCartAPI.DataTransferObjects.Readable;

namespace Services.ShoppingCartAPI.Contracts.IRepositoryManager.ShoppingCartRepositoryStore
{
    public interface ICartRepository
    {
        Task<CartDTO> GetCartByUserId(string userId);
        Task<CartDTO> CreateUpdateCart(CartDTO cartDto);
        Task<bool> RemoveFromCart(int cartDetailsId);
        Task<bool> ApplyCoupon(string userId, string couponCode);
        Task<bool> RemoveCoupon(string userId);
        Task<bool> ClearCart(string userId);
    }
}
