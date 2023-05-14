using CompsKitMarket.Core;
using Microsoft.AspNetCore.Mvc;

namespace CompsKitMarket.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly MarketContext _marketContext;

        public ManufacturerController(MarketContext marketContext)
        {
            _marketContext = marketContext;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
