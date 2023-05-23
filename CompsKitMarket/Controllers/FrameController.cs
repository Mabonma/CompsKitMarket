using CompsKitMarket.Core;
using CompsKitMarket.Core.Entities;
using CompsKitMarket.Core.Entities.Kits;
using CompsKitMarket.Extensions;
using CompsKitMarket.Models.Frame;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CompsKitMarket.Controllers
{
    public class FrameController : BasePartContoller
    {
        public FrameController(MarketContext marketContext) : base(marketContext)
        {
        }

        public ActionResult Index()
        {
            var items = _marketContext.Frames
                .OrderBy(x => x.Id)
                .Select(x => new FrameTable
                {
                    Id = x.Id,
                    Name = x.Name,
                    Data = _marketContext.Images.First(m => m.PartId == x.Id).Content,
                    Description = x.Description,
                    ManufacturerName = x.Manufacturer.Name,
                    ManufacturerId = x.ManufacturerID,
                    MotherFormName = x.MotherForm.Name,
                    Form = x.Form,
                    Color = x.Color,
                    Game = x.Game,
                    VideoLenght = x.VideoLenght,
                    CoolHeight = x.CoolHeight,
                    ChargeLength = x.ChargeLength,
                    Fans = x.Fans,
                    InsideHsdSize3 = x.InsideHsdSize3,
                    InsideHsdSize2 = x.InsideHsdSize2,
                })
                .ToList();

            return View(items);
        }

        public ActionResult Create()
        {
            var model = new FrameModel();
            FillDataManufacturers();
            FillDataMotherform();
            return View("CreateEdit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(FrameModel model)
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
                var enity = new Frame()
                {
                    Name = model.Name,
                    ManufacturerID = model.ManufacturerId,
                    Description = model.Description,
                    MotherFormId = model.MotherFormId,
                    Form = model.Form,
                    Color = model.Color,
                    Game = model.Game,
                    VideoLenght = model.VideoLenght,
                    CoolHeight = model.CoolHeight,
                    ChargeLength = model.ChargeLength,
                    Fans = model.Fans,
                    InsideHsdSize3 = model.InsideHsdSize3,
                    InsideHsdSize2 = model.InsideHsdSize2,
                    Images = new() { imageEntity }
                };
                _marketContext.Add(enity);
            }
            else
            {
                var old = _marketContext.Frames.First(x => x.Id == model.Id);
                old.Name = model.Name;
                old.ManufacturerID = model.ManufacturerId;
                old.Description = model.Description;
                old.MotherFormId = model.MotherFormId;
                old.Form = model.Form;
                old.Color = model.Color;
                old.Game = model.Game;
                old.VideoLenght = model.VideoLenght;
                old.CoolHeight = model.CoolHeight;
                old.ChargeLength = model.ChargeLength;
                old.Fans = model.Fans;
                old.InsideHsdSize3 = model.InsideHsdSize3;
                old.InsideHsdSize2 = model.InsideHsdSize2;
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
            var entity = await _marketContext.Frames
                .Select(x => new FrameModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    ManufacturerId = x.ManufacturerID,
                    MotherFormId = x.MotherForm.Id,
                    Form = x.Form,
                    Color = x.Color,
                    Game = x.Game,
                    VideoLenght = x.VideoLenght,
                    CoolHeight = x.CoolHeight,
                    ChargeLength = x.ChargeLength,
                    Fans = x.Fans,
                    InsideHsdSize3 = x.InsideHsdSize3,
                    InsideHsdSize2 = x.InsideHsdSize2,
                })
                .FirstAsync(x => x.Id == id);
            FillDataManufacturers();
            FillDataMotherform();

            return View("CreateEdit", entity);
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Frame entity = _marketContext.Frames.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                _marketContext.Frames.Remove(entity);
                _marketContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }


        public void FillDataMotherform()
        {
            ViewData["Motherforms"] = _marketContext.FormFactors
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }
    }
}
