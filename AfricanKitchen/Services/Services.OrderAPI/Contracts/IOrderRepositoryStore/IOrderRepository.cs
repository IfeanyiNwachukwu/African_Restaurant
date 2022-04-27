using Services.OrderAPI.Models;

namespace Services.OrderAPI.Contracts.IOrderRepositoryStore
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(OrderHeader orderHeader);
        Task UpdateOrderPaymentStatus(int orderheaderId, bool paid);
    }
}
