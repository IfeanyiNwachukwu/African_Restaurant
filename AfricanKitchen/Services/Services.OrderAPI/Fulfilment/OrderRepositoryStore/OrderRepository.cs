using Microsoft.EntityFrameworkCore;
using Services.OrderAPI.Contracts.IOrderRepositoryStore;
using Services.OrderAPI.DbContexts;
using Services.OrderAPI.Models;
using System.Diagnostics;

namespace Services.OrderAPI.Fulfilment.OrderRepositoryStore
{
    public class OrderRepository : IOrderRepository
    {
       
        private readonly DbContextOptions<ApplicationDbContext> _dbContext;
       /// <summary>
       /// To provide a single instance of DbContext
       /// </summary>
       /// <param name="dbContext"></param>
        public OrderRepository(DbContextOptions<ApplicationDbContext> dbContext)
        {
            _dbContext  = dbContext;
        }
        public async Task<bool> AddOrder(OrderHeader orderHeader)
        {
            try
            {
                await using var _db = new ApplicationDbContext(_dbContext);
                _db.OrderHeaders.Add(orderHeader);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                 Debug.WriteLine(ex.Message);
                 return false;
            }
        }

        public async Task UpdateOrderPaymentStatus(int orderheaderId, bool paid)
        {
            await using var _db = new ApplicationDbContext(_dbContext);
            var ordereaderFromDb = await _db.OrderHeaders.FirstOrDefaultAsync(u => u.OrderHeaderId == orderheaderId);
            
            if(ordereaderFromDb != null)
            {
                ordereaderFromDb.PaymentStatus = paid;
                await _db.SaveChangesAsync();

            }
        
        }
    }
}
