using AfricanKitchen.Web.Models;

namespace AfricanKitchen.Web.ServiceStore.IServices
{
    public interface ICartService
    {
        Task<T> GetCartByUserIdAsync<T>(string userId, string token = null);
        Task<T> AddToCartAsync<T>(CartDTO model, string token = null);
        Task<T> UpdateCartAsync<T>(CartDTO model, string token = null);
        Task<T> RemoveFromCartAsync<T>(int cartId, string token = null);
        Task<T> ApplyCoupon<T>(CartDTO cartDTO, string token = null);
        Task<T> RemoveCoupon<T>(string userId, string token = null);
    }
}
