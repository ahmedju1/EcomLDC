using Microsoft.AspNetCore.Mvc;

namespace EcomLDC.Api.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
