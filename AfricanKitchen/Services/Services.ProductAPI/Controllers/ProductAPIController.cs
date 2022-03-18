using Microsoft.AspNetCore.Mvc;

namespace Services.ProductAPI.Controllers
{
    public class ProductAPIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
