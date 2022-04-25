using AutoMapper;
using Services.CouponAPI.DTOs;
using Services.CouponAPI.Models;

namespace Services.CouponAPI.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CouponDTO, Coupon>().ReverseMap();
        }
    }
}
