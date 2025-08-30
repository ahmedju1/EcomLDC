
using Microsoft.AspNetCore.Mvc;

namespace EcomLDC.Api.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
