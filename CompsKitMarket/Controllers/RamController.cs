using CompsKitMarket.Core;
using CompsKitMarket.Core.Entities;
using CompsKitMarket.Core.Entities.Kits;
using CompsKitMarket.Extensions;
using CompsKitMarket.Models.Ram;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CompsKitMarket.Controllers
{
    public class RamController : BasePartContoller
    {
        public RamController(MarketContext marketContext) : base(marketContext)
        {
        }

        public IActionResult Index()
        {
            var items = _marketContext.Rams
                .Select(x => new RamTable
                {
                    Id = x.Id,
                    Name = x.Name,
                    Data = x.Images.First(m => m.PartId == x.Id).Content,
                    Description = x.Description,
                    ManufacturerName = x.Manufacturer.Name,
                    TypeName = x.Type.Name,
                    Vol = x.Vol,
                    Count = x.Count,
                    Freq = x.Freq,
                    Timings = x.Timings,
                })
                .ToList();
            return View(items);
        }

        public ActionResult Create()
        {
            var model = new RamModel();
            FillDataManufacturers();
            FillAllData();
            return View("CreateEdit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(RamModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateEdit", model);
            }

            if (model.IsNew)
            {
                var imageEntity = new Image()
                {
                    Name = model.Image.FileName,
                    Content = model.Image.ToByteArray(),
                    Type = model.Image.GetExtension(),
                };
                var enity = new Ram()
                {
                    Name = model.Name,
                    ManufacturerID = model.ManufacturerId,
                    Description = model.Description,
                    TypeId = model.TypeId,
                    Vol = model.Vol,
                    Count = model.Count,
                    Freq = model.Freq,
                    Timings = model.Timings,
                    Images = new() { imageEntity }
                };
                _marketContext.Add(enity);
            }
            else
            {
                var old = _marketContext.Rams.First(x => x.Id == model.Id);
                old.Name = model.Name;
                old.ManufacturerID = model.ManufacturerId;
                old.Description = model.Description;
                old.TypeId = model.TypeId;
                old.Vol = model.Vol;
                old.Count = model.Count;
                old.Freq = model.Freq;
                old.Timings = model.Timings;
                var image = model.Image.ToByteArray();
                if (image != null)
                {
                    var imageEntity = _marketContext.Images.First(x => x.PartId == model.Id);
                    imageEntity.Content = image;
                    imageEntity.Name = model.Image.Name;
                    imageEntity.Type = model.Image.GetExtension();
                }
            }
            _marketContext.SaveChanges();

            return View("Index");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _marketContext.Rams
                .Select(x => new RamModel
                {

                    Id = x.Id,
                    Name = x.Name,
                    ManufacturerId = x.ManufacturerID,
                    Description = x.Description,
                    TypeId = x.TypeId,
                    Vol = x.Vol,
                    Count = x.Count,
                    Freq = x.Freq,
                    Timings = x.Timings,
                })
                .FirstAsync(x => x.Id == id);
            FillDataManufacturers();
            FillAllData();

            return View("CreateEdit", entity);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Ram entity = _marketContext.Rams.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                _marketContext.Rams.Remove(entity);
                _marketContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public void FillAllData()
        {
            ViewData["TypeRams"] = _marketContext.TypeRams
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }
    }
}
