using CompsKitMarket.Core;
using CompsKitMarket.Core.Entities;
using CompsKitMarket.Core.Entities.Enums;
using CompsKitMarket.Core.Entities.Kits;
using CompsKitMarket.Core.Entities.Orders;
using CompsKitMarket.Extensions;
using CompsKitMarket.Models.Cooler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CompsKitMarket.Controllers
{
    public class CoolerController : BasePartContoller
    {
        public CoolerController(MarketContext marketContext) : base(marketContext)
        {
        }

        public IActionResult Index()
        {
            var items = _marketContext.Coolers
                .Select(x => new CoolerTable
                {
                    Id = x.Id,
                    Name = x.Name,
                    Data = x.Images.First(m => m.PartId == x.Id).Content,
                    Description = x.Description,
                    ManufacturerName = x.Manufacturer.Name,
                    CoolerTypeName = x.CoolerTypes.Name,
                    ProcSocketName = x.Socket.Name,
                    TypeCooling = x.TypeCooling,
                    Diam = x.Diam,
                    Tdp = x.Tdp,
                    CountFan = x.CountFan,
                    Height = x.Height,
                    Width = x.Width,
                    Rpm = x.Rpm,
                })
                .ToList();
            return View(items);
        }

        public ActionResult Create()
        {
            var model = new CoolerModel();
            FillDataManufacturers();
            FillAllData();
            return View("CreateEdit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CoolerModel model)
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
                var enity = new Cooler()
                {
                    Name = model.Name,
                    ManufacturerID = model.ManufacturerId,
                    Description = model.Description,
                    SocketId = model.ProcSocketId,
                    CoolerTypeId = model.CoolerTyperId,
                    TypeCooling = model.TypeCooling,
                    Diam = model.Diam,
                    Tdp = model.Tdp,
                    CountFan = model.CountFan,
                    Height = model.Height,
                    Width = model.Width,
                    Rpm = model.Rpm,
                    Images = new() { imageEntity }
                };
                _marketContext.Add(enity);
            }
            else
            {
                var old = _marketContext.Coolers.First(x => x.Id == model.Id);
                old.Name = model.Name;
                old.ManufacturerID = model.ManufacturerId;
                old.Description = model.Description;
                old.SocketId = model.ProcSocketId;
                old.CoolerTypeId = model.CoolerTyperId;
                old.TypeCooling = model.TypeCooling;
                old.Diam = model.Diam;
                old.Tdp = model.Tdp;
                old.CountFan = model.CountFan;
                old.Height = model.Height;
                old.Width = model.Width;
                old.Rpm = model.Rpm;
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
            var entity = await _marketContext.Coolers
                .Select(x => new CoolerModel
                {

                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    ManufacturerId = x.ManufacturerID,
                    CoolerTyperId = x.CoolerTypeId,
                    ProcSocketId = x.SocketId,
                    TypeCooling = x.TypeCooling,
                    Diam = x.Diam,
                    Tdp = x.Tdp,
                    CountFan = x.CountFan,
                    Height = x.Height,
                    Width = x.Width,
                    Rpm = x.Rpm,
                })
                .FirstAsync(x => x.Id == id);
            FillDataManufacturers();
            FillAllData();

            return View("CreateEdit", entity);
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Cooler entity = _marketContext.Coolers.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                _marketContext.Coolers.Remove(entity);
                _marketContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public void FillAllData()
        {
            ViewData["CoolerTypes"] = _marketContext.CoolerTypes
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            ViewData["ProcSockets"] = _marketContext.ProcSockets
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }
    }
}
