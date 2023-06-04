using CompsKitMarket.Core;
using CompsKitMarket.Core.Entities;
using CompsKitMarket.Core.Entities.Kits;
using CompsKitMarket.Extensions;
using CompsKitMarket.Models.Motherboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CompsKitMarket.Controllers
{
    public class MotherboardController : BasePartContoller
    {
        public MotherboardController(MarketContext marketContext) : base(marketContext)
        {
        }

        public IActionResult Index()
        {
            var items = _marketContext.Motherboards
                .Select(x => new MotherTable
                {
                    Id = x.Id,
                    Name = x.Name,
                    Data = x.Images.First(m => m.PartId == x.Id).Content,
                    Description = x.Description,
                    ManufacturerName = x.Manufacturer.Name,
                    FormFactorName = x.FormFactor.Name,
                    TypeRamName = x.TypeRam.Name,
                    CountRam = x.CountRam,
                    RamFreq = x.RamFreq,
                    M2 = x.M2,
                    Sata3 = x.Sata3,
                    Pci16 = x.Pci16,
                    Pci8 = x.Pci8,
                    Pci4 = x.Pci4,
                    Pci1 = x.Pci1,
                    ProcSocketName = x.ProcSocket.Name,
                })
                .ToList();
            return View(items);
        }

        public ActionResult Create()
        {
            var model = new MotherModel();
            FillDataManufacturers();
            FillAllData();
            return View("CreateEdit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MotherModel model)
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
                var enity = new Motherboard()
                {
                    Name = model.Name,
                    ManufacturerID = model.ManufacturerId,
                    Description = model.Description,
                    FormFactorId = model.FormFactorId,
                    TypeRamId = model.TypeRamId,
                    CountRam = model.CountRam,
                    RamFreq = model.RamFreq,
                    M2 = model.M2,
                    Sata3 = model.Sata3,
                    Pci16 = model.Pci16,
                    Pci8 = model.Pci8,
                    Pci4 = model.Pci4,
                    Pci1 = model.Pci1,
                    ProcSocketId = model.ProcSocketId,
                    Images = new() { imageEntity }
                };
                _marketContext.Add(enity);
            }
            else
            {
                var old = _marketContext.Motherboards.First(x => x.Id == model.Id);
                old.Name = model.Name;
                old.ManufacturerID = model.ManufacturerId;
                old.Description = model.Description;
                old.FormFactorId = model.FormFactorId;
                old.TypeRamId = model.TypeRamId;
                old.CountRam = model.CountRam;
                old.RamFreq = model.RamFreq;
                old.M2 = model.M2;
                old.Sata3 = model.Sata3;
                old.Pci16 = model.Pci16;
                old.Pci8 = model.Pci8;
                old.Pci4 = model.Pci4;
                old.Pci1 = model.Pci1;
                old.ProcSocketId = model.ProcSocketId;
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
            var entity = await _marketContext.Motherboards
                .Select(x => new MotherModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    ManufacturerId = x.ManufacturerID,
                    FormFactorId = x.FormFactorId,
                    TypeRamId = x.TypeRamId,
                    CountRam = x.CountRam,
                    RamFreq = x.RamFreq,
                    M2 = x.M2,
                    Sata3 = x.Sata3,
                    Pci16 = x.Pci16,
                    Pci8 = x.Pci8,
                    Pci4 = x.Pci4,
                    Pci1 = x.Pci1,
                    ProcSocketId = x.ProcSocketId,
                })
                .FirstAsync(x => x.Id == id);
            FillDataManufacturers();
            FillAllData();

            return View("CreateEdit", entity);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Motherboard entity = _marketContext.Motherboards.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                _marketContext.Motherboards.Remove(entity);
                _marketContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public void FillAllData()
        {
            ViewData["Motherforms"] = _marketContext.FormFactors
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            ViewData["TypeRams"] = _marketContext.TypeRams
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();


            ViewData["ProcSockets"] = _marketContext.ProcSockets
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }
    }
}
