using CompsKitMarket.Core;
using CompsKitMarket.Core.Entities;
using CompsKitMarket.Core.Entities.Enums;
using CompsKitMarket.Core.Entities.Kits;
using CompsKitMarket.Core.Entities.Orders;
using CompsKitMarket.Extensions;
using CompsKitMarket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace CompsKitMarket.Controllers
{ 
    public class HsdController : BasePartContoller
    {

        public HsdController(MarketContext marketContext) : base (marketContext)
        {
        }

        public ActionResult Index()
        {
            var items = _marketContext.Hsds
                .OrderBy(x => x.Id)
                .Select(x => new HsdModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Data = _marketContext.Images.First(m => m.PartId == x.Id).Content,
                    ManufacturerName = x.Manufacturer.Name,
                    ManufacturerId = x.ManufacturerID,
                    Type = x.Type,
                    Description = x.Description,
                    Form = x.Form,
                    Connections = x.Connections,
                    Vol = x.Vol,
                    Deleted = x.Deleted,
                })
                .ToList();
            //HsdModel hsd = new() 
            //{
            //    Id = 1,
            //    Name = "TurboVol",
            //    Description = "",
            //    Type = HsdTypes.Hdd,
            //    Connections = HsdConnections.Sata3,
            //    Vol = 500,
            //    Form = HsdForms.Full,
            //    Deleted = false
            //};
            //List<HsdModel> hsds = new()
            //{
            //    hsd,
            //    (HsdModel) hsd.Clone(),
            //    (HsdModel) hsd.Clone(),
            //    (HsdModel) hsd.Clone(),
            //    (HsdModel) hsd.Clone()
            //};
            //hsds[1].Id = 2;
            //hsds[2].Id = 3;
            //hsds[3].Id = 4;

            return View(/*hsds*/items);
        }

        public ActionResult Create()
        {
            var enity = new HsdModel();
            FillDataManufacturers();
            return View("CreateEdit", enity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(HsdModel model)
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
                var enity = new Hsd()
                {
                    Name = model.Name,
                    ManufacturerID = model.ManufacturerId,
                    Type = model.Type,
                    Description = model.Description,
                    Connections = model.Connections,
                    Vol = model.Vol,
                    Form = model.Form,
                    Images = new () { imageEntity }
                };
                _marketContext.Add(enity);
            }
            else
            {
                var old = _marketContext.Hsds.First(x => x.Id == model.Id);
                old.Name = model.Name;
                old.ManufacturerID = model.ManufacturerId;
                old.Type = model.Type;
                old.Description = model.Description;
                old.Connections = model.Connections;
                old.Vol = model.Vol;
                old.Form = model.Form;
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
            var entity = await _marketContext.Hsds
                .Select(x => new HsdModel
                {
                    Id = x.Id,
                    ManufacturerName = x.Manufacturer.Name,
                    Type = x.Type,
                    Description = x.Description,
                    Form = x.Form,
                    Connections = x.Connections,
                    Vol = x.Vol,
                    Deleted = x.Deleted,
                })
                .FirstAsync(x => x.Id == id);
            FillDataManufacturers();

            return View("CreateEdit", entity);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Hsd hsd = _marketContext.Hsds.FirstOrDefault(hsd => hsd.Id == id);
            if (hsd != null)
            {
                _marketContext.Hsds.Remove(hsd);
                _marketContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
