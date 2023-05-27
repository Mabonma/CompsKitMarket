using CompsKitMarket.Core;
using CompsKitMarket.Core.Entities;
using CompsKitMarket.Core.Entities.Kits;
using CompsKitMarket.Extensions;
using CompsKitMarket.Models.Cpu;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CompsKitMarket.Controllers
{
    public class CpuController : BasePartContoller
    {
        public CpuController(MarketContext marketContext) : base(marketContext)
        {
        }

        public IActionResult Index()
        {
            var items = _marketContext.Cpus
                .Select(x => new CpuTable
                {
                    Id = x.Id,
                    Name = x.Name,
                    Data = x.Images.First(m => m.PartId == x.Id).Content,
                    Description = x.Description,
                    ManufacturerName = x.Manufacturer.Name,
                    ProcSocketName = x.ProcSocket.Name,
                    ProcModelName = x.ProcModel.Name,
                    Cores = x.Cores,
                    Graf = x.Graf,
                    Crystal = x.Crystal,
                    BaseFreq = x.BaseFreq,
                    MaxFreq = x.MaxFreq,
                    MultiThread = x.MultiThread,
                    Tdp = x.Tdp,
                    BoxType = x.BoxType,
                    Tehprocess = x.Tehprocess,
                    TypeRamName = x.TypeRam.Name,
                })
                .ToList();
            return View(items);
        }

        public ActionResult Create()
        {
            var model = new CpuModel();
            FillDataManufacturers();
            FillAllData();
            return View("CreateEdit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CpuModel model)
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
                var enity = new Cpu()
                {
                    Name = model.Name,
                    ManufacturerID = model.ManufacturerId,
                    Description = model.Description,
                    ProcSocketId = model.ProcSocketId,
                    ProcModelId = model.ProcModelId,
                    Cores = model.Cores,
                    Graf = model.Graf,
                    Crystal = model.Crystal,
                    BaseFreq = model.BaseFreq,
                    MaxFreq = model.MaxFreq,
                    MultiThread = model.MultiThread,
                    Tdp = model.Tdp,
                    BoxType = model.BoxType,
                    Tehprocess = model.Tehprocess,
                    TypeRamId = model.TypeRamId,
                    Images = new() { imageEntity }
                };
                _marketContext.Add(enity);
            }
            else
            {
                var old = _marketContext.Cpus.First(x => x.Id == model.Id);
                old.Name = model.Name;
                old.ManufacturerID = model.ManufacturerId;
                old.Description = model.Description;
                old.ProcSocketId = model.ProcSocketId;
                old.ProcModelId = model.ProcModelId;
                old.Cores = model.Cores;
                old.Graf = model.Graf;
                old.Crystal = model.Crystal;
                old.BaseFreq = model.BaseFreq;
                old.MaxFreq = model.MaxFreq;
                old.MultiThread = model.MultiThread;
                old.Tdp = model.Tdp;
                old.BoxType = model.BoxType;
                old.Tehprocess = model.Tehprocess;
                old.TypeRamId = model.TypeRamId;
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
            var entity = await _marketContext.Cpus
                .Select(x => new CpuModel
                {

                    Id = x.Id,
                    Name = x.Name,
                    ManufacturerId = x.ManufacturerID,
                    Description = x.Description,
                    ProcSocketId = x.ProcSocketId,
                    ProcModelId = x.ProcModelId,
                    Cores = x.Cores,
                    Graf = x.Graf,
                    Crystal = x.Crystal,
                    BaseFreq = x.BaseFreq,
                    MaxFreq = x.MaxFreq,
                    MultiThread = x.MultiThread,
                    Tdp = x.Tdp,
                    BoxType = x.BoxType,
                    Tehprocess = x.Tehprocess,
                    TypeRamId = x.TypeRamId,
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
            Cpu entity = _marketContext.Cpus.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                _marketContext.Cpus.Remove(entity);
                _marketContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public void FillAllData()
        {
            ViewData["ProcSockets"] = _marketContext.ProcSockets
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            ViewData["ProcModels"] = _marketContext.ProcModels
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();


            ViewData["TypeRams"] = _marketContext.TypeRams
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }
    }
}
