using CompsKitMarket.Core.Entities.Orders;
using CompsKitMarket.Core;
using CompsKitMarket.Models.Manufacturer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CompsKitMarket.Models.Store;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CompsKitMarket.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompsKitMarket.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class StoreController : Controller
    {
        private readonly MarketContext _marketContext;

        public StoreController(MarketContext marketContext)
        {
            _marketContext = marketContext;
        }

        public IActionResult Index()
        {
            var items = _marketContext.Stores
                .OrderBy(x => x.Id)
                .Select(x => new StoreTable
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    WorkMode = x.WorkMode,
                    Phone = x.Phone,
                    Address = x.Address,
                    Mail = x.Mail,
                    PartsCount = x.PartStores.Count,
                })
                .ToList();
            return View(items);
        }

        public async Task<IActionResult> PartsGridPartial(int id)
        {
            var data = await _marketContext.PartStores
                .Where(x => x.StoreId == id)
                .Select(x => new PartStoreModel
                {
                    Id = x.Part.Id,
                    StoreId = id,
                    Name = x.Part.Name,
                    Description = x.Part.Description,
                    ManufacturerName = x.Part.Manufacturer.Name,
                    Cost = x.Cost,
                })
                .ToListAsync();
            return PartialView("_PartsGridPartial", data);
        }

        public IActionResult AddPartCost()
        {
            var entity = new PartStoreModel();

            ViewData["Parts"] = _marketContext.Parts
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            return PartialView("_PartFormPartial", entity);
        }

        public async Task<IActionResult> EditPartCost(int partId, int storeId)
        {
            var entity = await _marketContext.PartStores
                .Select(x => new PartStoreModel
                {
                    Id = x.Part.Id,
                    StoreId = x.StoreId,
                    Name = x.Part.Name,
                    Description = x.Part.Description,
                    ManufacturerName = x.Part.Manufacturer.Name,
                    Cost = x.Cost,
                })
                .FirstAsync(x => x.Id == partId && x.StoreId == storeId);
            return PartialView("_PartFormPartial", entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task SavePartCost(PartStoreModel model)
        {
            if (model.IsNew)
            {
                _marketContext.Add(new PartStore
                {
                    PartId = model.Id,
                    StoreId = model.Id,
                    Cost = model.Cost,
                });
            }
            else
            {
                var old = await _marketContext.PartStores.FirstAsync(x => x.PartId == model.Id && x.StoreId == model.StoreId);
                old.Cost = model.Cost;
            }
            await _marketContext.SaveChangesAsync();
        }

        [HttpPost]
        public async Task RemovePartCost(int partId, int storeId)
        {
            var entity = await _marketContext.PartStores.FirstAsync(x => x.PartId == partId && x.StoreId == storeId);
            _marketContext.Remove(entity);
            await _marketContext.SaveChangesAsync();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var entity = new StoreModel();
            return View("CreateEdit", entity);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var entity = _marketContext.Stores
                .Select(x => new StoreModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    WorkMode = x.WorkMode,
                    Phone = x.Phone,
                    Address = x.Address,
                    Mail = x.Mail,
                    PartsCount = x.PartStores.Count,
                })
                .First(x => x.Id == id);
            return View("CreateEdit", entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(StoreModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("CreateEdit", model);
                }

                if (model.IsNew)
                {
                    _marketContext.Add(new Store
                    {
                        Name = model.Name,
                        Description = model.Description,
                        WorkMode = model.WorkMode,
                        Phone = model.Phone,
                        Address = model.Address,
                        Mail = model.Mail,
                    });
                }
                else
                {
                    var old = _marketContext.Stores.First(x => x.Id == model.Id);
                    old.Name = model.Name;
                    old.Description = model.Description;
                    old.WorkMode = model.WorkMode;
                    old.Phone = model.Phone;
                    old.Address = model.Address;
                    old.Mail = model.Mail;
                }
                _marketContext.SaveChanges();

                return RedirectToAction("Index");
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
