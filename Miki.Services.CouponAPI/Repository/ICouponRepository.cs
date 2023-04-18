using Miki.Services.CouponAPI.Models.DTO;

namespace Miki.Services.CouponAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCode(string couponCode);

    }
}
