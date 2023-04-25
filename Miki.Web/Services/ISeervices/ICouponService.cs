using Miki.Web.Models;

namespace Miki.Web.Services.ISeervices
{
    public interface ICouponService
    {
        Task<T> GetCoupon<T>(string couponCode, string token = null);

    }
}
