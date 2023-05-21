using CompsKitMarket.Core;
using CompsKitMarket.Models.Image;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CompsKitMarket.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ImageController : Controller
    {
        private readonly MarketContext _marketContext;

        public ImageController(MarketContext marketContext)
        {
            _marketContext = marketContext;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var items = _marketContext.Images
                .OrderBy(x => x.Id)
                .Select(x => new ImageTable
                { 
                    Id = x.Id,
                    Name = x.Name,
                    Content = x.Content,
                    Type = x.Type,
                })
                .ToList();
            return View(items);
        }
    }
}
