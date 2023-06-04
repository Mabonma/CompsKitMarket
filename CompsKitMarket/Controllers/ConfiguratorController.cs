using Microsoft.AspNetCore.Mvc;

namespace CompsKitMarket.Controllers
{
    public class ConfiguratorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
