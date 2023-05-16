using CompsKitMarket.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq;

namespace CompsKitMarket.Controllers
{
    public abstract class BasePartContoller : Controller
    {
        protected readonly MarketContext _marketContext;

        public BasePartContoller(MarketContext marketContext)
        {
            _marketContext = marketContext;
        }

        public void FillDataManufacturers()
        {
            ViewData["Manufacturers"] = _marketContext.Manufacturers
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }
    }
}
