using CompsKitMarket.Core;
using CompsKitMarket.Core.Entities.Kits;
using CompsKitMarket.Core.Entities.Orders;
using CompsKitMarket.Models;
using CompsKitMarket.Models.Manufacturer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CompsKitMarket.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManufacturerController : Controller
    {
        private readonly MarketContext _marketContext;

        public ManufacturerController(MarketContext marketContext)
        {
            _marketContext = marketContext;
        }

        public IActionResult Index()
        {
            var items = _marketContext.Manufacturers
                .OrderBy(x => x.Id)
                .Select(x => new ManufacturerModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    PartCount = x.Parts.Count,
                })
                .ToList();
            return View(items);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var entity = new ManufacturerModel();
            return View("CreateEdit", entity);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var entity = _marketContext.Manufacturers
                .Select(x => new ManufacturerModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    PartCount = x.Parts.Count,
                })
                .First(x => x.Id == id);
            return View("CreateEdit", entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ManufacturerModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("CreateEdit", model);
                }

                if (model.IsNew)
                {
                    _marketContext.Add(new Manufacturer()
                    {
                        Name = model.Name,
                        Description = model.Description,
                    });
                }
                else
                {
                    var old = _marketContext.Manufacturers.First(x => x.Id == model.Id);
                    old.Name = model.Name;
                    old.Description = model.Description;
                }
                _marketContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Manufacturer manufacturer = _marketContext.Manufacturers.FirstOrDefault(manufacturer => manufacturer.Id == id);
            if (manufacturer != null)
            {
                _marketContext.Manufacturers.Remove(manufacturer);
                _marketContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
