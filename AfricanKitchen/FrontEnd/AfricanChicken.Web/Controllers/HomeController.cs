using AfricanKitchen.Web.Models;
using AfricanKitchen.Web.ServiceStore.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AfricanKitchen.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public HomeController(ILogger<HomeController> logger,IProductService productService,ICartService cartService)
        {
            _logger = logger;
            _productService = productService;
            _cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductDTO> productList = new();
            var response = await _productService.GetAllProductsAsync<ResponseDTO>("");
            if(response != null && response.IsSuccess)
            {
                productList = JsonConvert.DeserializeObject<List<ProductDTO>>(Convert.ToString(response.Result));
            }
            return View(productList);
        }

        [Authorize]
        public async Task<IActionResult> Details(int productId)
        {
            ProductDTO product = new();
            var response = await _productService.GetProductsByIdAsync<ResponseDTO>(productId,"");
            if (response != null && response.IsSuccess)
            {
                product = JsonConvert.DeserializeObject<ProductDTO>(Convert.ToString(response.Result));
            }
            return View(product);
        }
        [HttpPost]
        [Authorize]
        [ActionName("Details")]
        public async Task<IActionResult> DetailsPost(ProductDTO productDTO)
        {
            CartDTO cartDTO = new()
            {
                CartHeader = new CartHeaderDTO()
                {
                    UserId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value
                }
            };
            CartDetailsDTO cartDetails = new CartDetailsDTO()
            {
                Count = productDTO.Count,
                ProductId = productDTO.ProductId
            };
            var response = await _productService.GetProductsByIdAsync<ResponseDTO>(productDTO.ProductId, "");
            
            if(response != null && response.IsSuccess)
            {
                cartDetails.Product = JsonConvert.DeserializeObject<ProductDTO>(Convert.ToString(response.Result));
            }
            List<CartDetailsDTO> cartDetailsDTOs = new();
            cartDetailsDTOs.Add(cartDetails);
            cartDTO.CartDetails = cartDetailsDTOs;

            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var addToCartResponse = await _cartService.AddToCartAsync<ResponseDTO>(cartDTO, accessToken);
            if (addToCartResponse != null && addToCartResponse.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(productDTO);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize]
        public async Task<IActionResult> Login()
        {
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
       
    }
}