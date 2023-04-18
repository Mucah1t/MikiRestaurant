using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Miki.Web.Models;
using Miki.Web.Services.ISeervices;
using Newtonsoft.Json;

namespace Miki.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public CartController(IProductService productService, ICartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }

        public async Task<IActionResult> CartIndex()
        {
            return View(await LoadCartDtoBasedOnLoggedInUser());
        }
        private async Task<CartDto> LoadCartDtoBasedOnLoggedInUser()
        {
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;
            var accesToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _cartService.GetCartByUserIdAsnyc<ResponseDto>(userId,accesToken);

            CartDto carDto = new();
            if (response!= null && response.IsSuccess)
            {
                carDto = JsonConvert.DeserializeObject<CartDto>(Convert.ToString(response.Result));
            }
            if (carDto.CartHeader != null)
            {
                foreach (var detail in carDto.CartDetails)
                {
                    carDto.CartHeader.OrderTotal += Convert.ToDouble(detail.Product.Price * detail.Count);
                }
            }
            return carDto;
        }
        public async Task<IActionResult> Remove(int cartDetailsId)
        {
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _cartService.RemoveFromCartAsync<ResponseDto>(cartDetailsId, accessToken);


            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(CartIndex));
            }
            return View();
        }
    }
}
