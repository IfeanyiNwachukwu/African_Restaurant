using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Services.CouponAPI.Contracts.CouponRepositoryStore;
using Services.CouponAPI.DbContexts;
using Services.CouponAPI.DTOs;

namespace Services.CouponAPI.Fulfilment.CouponRepositoryStore
{
    public class CouponRepository : ICouponRepository
    {
        private readonly ApplicationDbContext _db;
        protected IMapper _mapper;
        public CouponRepository(ApplicationDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<CouponDTO> GetCouponByCode(string couponCode)
        {
            var couponFromDb = _db.Coupons.FirstOrDefaultAsync(x => x.CouponCode == couponCode);

            return _mapper.Map<CouponDTO>(couponFromDb);
        }
    }
}
