using Microsoft.AspNetCore.Mvc;

namespace EcomLDC.Api.DTOs
{
    public class OrderRequest : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
