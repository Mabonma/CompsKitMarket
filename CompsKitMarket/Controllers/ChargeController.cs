using CompsKitMarket.Core;
using CompsKitMarket.Core.Entities;
using CompsKitMarket.Core.Entities.Kits;
using CompsKitMarket.Extensions;
using CompsKitMarket.Models.Charge;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CompsKitMarket.Controllers
{
    public class ChargeController : BasePartContoller
    {
        public ChargeController(MarketContext marketContext) : base(marketContext)
        {
        }

        public ActionResult Index()
        {
            var items = _marketContext.Charges
                .OrderBy(x => x.Id)
                .Select(x => new ChargeTable
                {
                    Id = x.Id,
                    Name = x.Name,
                    Data = _marketContext.Images.First(m => m.PartId == x.Id).Content,
                    Description = x.Description,
                    ManufacturerName = x.Manufacturer.Name,
                    ManufacturerId = x.ManufacturerID,
                    Cpu4 = x.Cpu4,
                    Cpu8 = x.Cpu8,
                    Sata = x.Sata,
                    Pcle6 = x.Pcle6,
                    Pcle8 = x.Pcle8,
                    Pcle16 = x.Pcle16,
                    Fdd = x.Fdd,
                    Ide = x.Ide,
                    Usb = x.Usb,
                    Height = x.Height,
                    Width = x.Width,
                    Deep = x.Deep,
                })
                .ToList();

            return View(items);
        }

        public ActionResult Create()
        {
            var model = new ChargeModel();
            FillDataManufacturers();
            return View("CreateEdit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ChargeModel model)
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
                var enity = new Charge()
                {
                    Name = model.Name,
                    ManufacturerID = model.ManufacturerId,
                    Description = model.Description,
                    Cpu4 = model.Cpu4,
                    Cpu8 = model.Cpu8,
                    Sata = model.Sata,
                    Pcle6 = model.Pcle6,
                    Pcle8 = model.Pcle8,
                    Pcle16 = model.Pcle16,
                    Fdd = model.Fdd,
                    Ide = model.Ide,
                    Usb = model.Usb,
                    Height = model.Height,
                    Width = model.Width,
                    Deep = model.Deep,
                    Images = new() { imageEntity }
                };
                _marketContext.Add(enity);
            }
            else
            {
                var old = _marketContext.Charges.First(x => x.Id == model.Id);
                old.Name = model.Name;
                old.ManufacturerID = model.ManufacturerId;
                old.Description = model.Description;
                old.Cpu4 = model.Cpu4;
                old.Cpu8 = model.Cpu8;
                old.Sata = model.Sata;
                old.Pcle6 = model.Pcle6;
                old.Pcle8 = model.Pcle8;
                old.Pcle16 = model.Pcle16;
                old.Fdd = model.Fdd;
                old.Ide = model.Ide;
                old.Usb = model.Usb;
                old.Height = model.Height;
                old.Width = model.Width;
                old.Deep = model.Deep;
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
            var entity = await _marketContext.Charges
                .Select(x => new ChargeModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    Cpu4 = x.Cpu4,
                    Cpu8 = x.Cpu8,
                    Sata = x.Sata,
                    Pcle6 = x.Pcle6,
                    Pcle8 = x.Pcle8,
                    Pcle16 = x.Pcle16,
                    Fdd = x.Fdd,
                    Ide = x.Ide,
                    Usb = x.Usb,
                    Height = x.Height,
                    Width = x.Width,
                    Deep = x.Deep,
                })
                .FirstAsync(x => x.Id == id);
            FillDataManufacturers();

            return View("CreateEdit", entity);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Charge charge = _marketContext.Charges.FirstOrDefault(x => x.Id == id);
            if (charge != null)
            {
                _marketContext.Charges.Remove(charge);
                _marketContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
