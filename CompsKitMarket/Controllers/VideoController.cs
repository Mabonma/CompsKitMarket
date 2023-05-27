using CompsKitMarket.Core;
using CompsKitMarket.Core.Entities;
using CompsKitMarket.Core.Entities.Kits;
using CompsKitMarket.Extensions;
using CompsKitMarket.Models.Video;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CompsKitMarket.Controllers
{
    public class VideoController : BasePartContoller
    {
        public VideoController(MarketContext marketContext) : base(marketContext)
        {
        }
        public IActionResult Index()
        {
            var items = _marketContext.Videos
                .Select(x => new VideoTable
                {
                    Id = x.Id,
                    Name = x.Name,
                    Data = x.Images.First(m => m.PartId == x.Id).Content,
                    Description = x.Description,
                    ManufacturerName = x.Manufacturer.Name,
                    GrafProcName = x.GrafProc.Name,
                    GrafProcManuf = x.GrafProc.GProcs,
                    VramVol = x.VramVol,
                    VramTypeName = x.VramType.Name,
                    BusInter = x.BusInter,
                    Cooling = x.Cooling,
                    Rtx = x.Rtx,
                })
                .ToList();
            return View(items);
        }

        public ActionResult Create()
        {
            var model = new VideoModel();
            FillDataManufacturers();
            FillAllData();
            return View("CreateEdit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(VideoModel model)
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
                var enity = new Video()
                {
                    Name = model.Name,
                    ManufacturerID = model.ManufacturerId,
                    Description = model.Description,
                    GrafProcId = model.GrafProcId,
                    VramVol = model.VramVol,
                    VramTypeId = model.VramTypeId,
                    BusInter = model.BusInter,
                    Cooling = model.Cooling,
                    Rtx = model.Rtx,
                    Images = new() { imageEntity }
                };
                _marketContext.Add(enity);
            }
            else
            {
                var old = _marketContext.Videos.First(x => x.Id == model.Id);
                old.Name = model.Name;
                old.ManufacturerID = model.ManufacturerId;
                old.Description = model.Description;
                old.GrafProcId = model.GrafProcId;
                old.VramVol = model.VramVol;
                old.VramTypeId = model.VramTypeId;
                old.BusInter = model.BusInter;
                old.Cooling = model.Cooling;
                old.Rtx = model.Rtx;
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
            var entity = await _marketContext.Videos
                .Select(x => new VideoModel
                {

                    Id = x.Id,
                    Name = x.Name,
                    ManufacturerId = x.ManufacturerID,
                    Description = x.Description,
                    GrafProcId = x.GrafProcId,
                    VramVol = x.VramVol,
                    VramTypeId = x.VramTypeId,
                    BusInter = x.BusInter,
                    Cooling = x.Cooling,
                    Rtx = x.Rtx,
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
            Video entity = _marketContext.Videos.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                _marketContext.Videos.Remove(entity);
                _marketContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public void FillAllData()
        {
            ViewData["GrafProc"] = _marketContext.GrafProcs
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            ViewData["TypeRams"] = _marketContext.TypeRams
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }
    }
}
