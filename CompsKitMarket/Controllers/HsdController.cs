using CompsKitMarket.Core;
using CompsKitMarket.Core.Entities.Enums;
using CompsKitMarket.Core.Entities.Kits;
using CompsKitMarket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompsKitMarket.Controllers
{
    public class HsdController : Controller
    {
        private readonly MarketContext _marketContext;

        public HsdController(MarketContext marketContext)
        {
            _marketContext = marketContext;
        }

        // GET: HsdController
        public ActionResult Index()
        {
            var items = _marketContext.Hsds
                .OrderBy(x => x.Id)
                .ToList()
                .Select(x => new HsdModel
                {
                    Id = x.Id,
                    Type = x.Type,
                    Description = x.Description,
                    Form = x.Form,
                    Connections = x.Connections,
                    Vol = x.Vol,
                    Deleted = x.Deleted,
                });
            /*HsdModel hsd = new() 
            {
                Id = 1,
                Name = "TurboVol",
                Description = "",
                Type = HsdTypes.Hdd,
                Connections = HsdConnections.Sata3,
                Vol = 500,
                Form = HsdForms.Full,
                Deleted = false
            };
            List<HsdModel> hsds = new() { hsd };
            hsds.Add(hsd);
            hsds.Add(hsd);
            hsds.Add(hsd);
            hsds.Add(hsd);*/

            return View(/*hsds*/items);
        }

        // GET: HsdController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            var enity = new HsdModel();
            return View("CreateEdit", enity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(HsdModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("CreateEdit", model);
                }

                if (model.IsNew)
                {
                    _marketContext.Add(new Hsd()
                    {
                        Name = model.Name,
                        Type = model.Type,
                        Description = model.Description,
                        Connections = model.Connections,
                        Vol = model.Vol,
                        Form = model.Form,
                    });
                }
                else
                {
                    var old = _marketContext.Hsds.First(x => x.Id == model.Id);
                    old.Name = model.Name;
                    old.Type = model.Type;
                    old.Description = model.Description; 
                    old.Connections = model.Connections;
                    old.Vol = model.Vol;
                    old.Form = model.Form;
                }
                _marketContext.SaveChanges();
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Authorize]
        // GET: HsdController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _marketContext.Hsds
                .Select(x => new HsdModel
                {
                    Id = x.Id,
                    Type = x.Type,
                    Description = x.Description,
                    Form = x.Form,
                    Connections = x.Connections,
                    Vol = x.Vol,
                    Deleted = x.Deleted,
                })
                .FirstAsync(x => x.Id == id);

            return View("CreateEdit", entity);
        }

        // POST: HsdController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HsdController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HsdController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
