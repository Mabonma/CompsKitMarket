using CompsKitMarket.Core;
using CompsKitMarket.Core.Entities.Enums;
using CompsKitMarket.Core.Entities.Kits;
using CompsKitMarket.Models.AdditionalInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CompsKitMarket.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdditionalInfoController : Controller
    {
        private readonly MarketContext _marketContext;

        public AdditionalInfoController(MarketContext marketContext)
        {
            _marketContext = marketContext;
        }

        #region FormFactor

        [HttpGet]
        //[Route("AdditionalInfo/FormFactor")]
        public ActionResult FormFactor()
        {
            var items = _marketContext.FormFactors
                .Select(x => new AdditionalInfoElement
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartCount = x.Motherboards.Count() + x.Frames.Count(),
                })
                .ToList();
            var model = new AdditionalInfoTable
            {
                AddToHtml = "FormFactor",
                Elements = items,
            };
            return View("Index", model);
        }

        [HttpGet]
        public ActionResult CreateFormFactor()
        {
            var model = new AdditionalInfoModel
            {
                AddToHtml = "FormFactor",
                Element = new AdditionalInfoElement(),
            };
            return View("CreateEdit", model);
        }

        [HttpGet]
        public ActionResult EditFormFactor(int id)
        {
            var entity = _marketContext.FormFactors
                .Select(x => new AdditionalInfoElement
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .First(x => x.Id == id);
            var model = new AdditionalInfoModel
            {
                AddToHtml = "FormFactor",
                Element = entity,
            };
            return View("CreateEdit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveFormFactor(AdditionalInfoModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateEdit", model);
            }

            if (model.Element.IsNew)
            {
                var entity = new FormFactor
                {
                    Name = model.Element.Name,
                };
                _marketContext.Add(entity);
            }
            else
            {
                var old = _marketContext.FormFactors.First(x => x.Id == model.Element.Id);
                old.Name = model.Element.Name;
            }
            _marketContext.SaveChanges();

            return View(model.AddToHtml, model);
        }


        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFormFactor(int id)
        {
            FormFactor formFactor = _marketContext.FormFactors.FirstOrDefault(formFactor => formFactor.Id == id);
            if (formFactor != null)
            {
                _marketContext.FormFactors.Remove(formFactor);
                _marketContext.SaveChanges();
                return View("FormFactor");
            }
            return NotFound();
        }

        #endregion

        #region ProcSocket

        [HttpGet]
        public ActionResult ProcSocket()
        {
            var items = _marketContext.ProcSockets
                .Select(x => new AdditionalInfoElement
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartCount = x.Motherboards.Count() + x.Cpus.Count(),
                })
                .ToList();
            var model = new AdditionalInfoTable
            {
                AddToHtml = "ProcSocket",
                Elements = items,
            };
            return View("Index", model);
        }

        [HttpGet]
        public ActionResult CreateProcSocket()
        {
            var entity = new AdditionalInfoModel
            {
                AddToHtml = "ProcSocket",
                Element = new AdditionalInfoElement(),
            };
            return View("CreateEdit", entity);
        }

        [HttpGet]
        public ActionResult EditProcSocket(int id)
        {
            var entity = _marketContext.ProcSockets
                .Select(x => new AdditionalInfoElement
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .First(x => x.Id == id);
            var model = new AdditionalInfoModel
            {
                AddToHtml = "ProcSocket",
                Element = entity,
            };
            return View("CreateEdit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveProcSocket(AdditionalInfoModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateEdit", model);
            }

            if (model.Element.IsNew)
            {
                var entity = new ProcSocket
                {
                    Name = model.Element.Name,
                };
                _marketContext.Add(entity);
            }
            else
            {
                var old = _marketContext.ProcSockets.First(x => x.Id == model.Element.Id);
                old.Name = model.Element.Name;
            }
            _marketContext.SaveChanges();

            return View(model.AddToHtml, model);
        }


        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProcSocket(int id)
        {
            ProcSocket procSocket = _marketContext.ProcSockets.FirstOrDefault(procSocket => procSocket.Id == id);
            if (procSocket != null)
            {
                _marketContext.ProcSockets.Remove(procSocket);
                _marketContext.SaveChanges();
                return View("ProcSocket");
            }
            return NotFound();
        }

        #endregion

        #region ProcModel

        [HttpGet]
        public ActionResult ProcModel()
        {
            var items = _marketContext.ProcModels
                .Select(x => new AdditionalInfoElement
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartCount = x.Cpus.Count(),
                })
                .ToList();
            var model = new AdditionalInfoTable
            {
                AddToHtml = "ProcModel",
                Elements = items,
            };
            return View("Index", model);
        }

        [HttpGet]
        public ActionResult CreateProcModel()
        {
            var entity = new AdditionalInfoModel
            {
                AddToHtml = "ProcModel",
                Element = new AdditionalInfoElement(),
            };
            return View("CreateEdit", entity);
        }

        [HttpGet]
        public ActionResult EditProcModel(int id)
        {
            var entity = _marketContext.ProcModels
                .Select(x => new AdditionalInfoElement
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .First(x => x.Id == id);
            var model = new AdditionalInfoModel
            {
                AddToHtml = "ProcModel",
                Element = entity,
            };
            return View("CreateEdit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveProcModel(AdditionalInfoModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateEdit", model);
            }

            if (model.Element.IsNew)
            {
                var entity = new ProcModel
                {
                    Name = model.Element.Name,
                };
                _marketContext.Add(entity);
            }
            else
            {
                var old = _marketContext.ProcModels.First(x => x.Id == model.Element.Id);
                old.Name = model.Element.Name;
            }
            _marketContext.SaveChanges();

            return View(model.AddToHtml, model);
        }


        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProcModel(int id)
        {
            ProcModel procModel = _marketContext.ProcModels.FirstOrDefault(procModel => procModel.Id == id);
            if (procModel != null)
            {
                _marketContext.ProcModels.Remove(procModel);
                _marketContext.SaveChanges();
                return View("ProcModel");
            }
            return NotFound();
        }

        #endregion

        #region TypeRam

        [HttpGet]
        public ActionResult TypeRam()
        {
            var items = _marketContext.TypeRams
                .Select(x => new AdditionalInfoElement
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartCount = x.Motherboards.Count() + x.Cpus.Count() + x.Videos.Count() + x.Rams.Count(),
                })
                .ToList();
            var model = new AdditionalInfoTable
            {
                AddToHtml = "TypeRam",
                Elements = items,
            };
            return View("Index", model);
        }

        [HttpGet]
        public ActionResult CreateTypeRam()
        {
            var entity = new AdditionalInfoModel
            {
                AddToHtml = "TypeRam",
                Element = new AdditionalInfoElement(),
            };
            return View("CreateEdit", entity);
        }

        [HttpGet]
        public ActionResult EditTypeRam(int id)
        {
            var entity = _marketContext.TypeRams
                .Select(x => new AdditionalInfoElement
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .First(x => x.Id == id);
            var model = new AdditionalInfoModel
            {
                AddToHtml = "TypeRam",
                Element = entity,
            };
            return View("CreateEdit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveTypeRam(AdditionalInfoModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateEdit", model);
            }

            if (model.Element.IsNew)
            {
                var entity = new TypeRam
                {
                    Name = model.Element.Name,
                };
                _marketContext.Add(entity);
            }
            else
            {
                var old = _marketContext.TypeRams.First(x => x.Id == model.Element.Id);
                old.Name = model.Element.Name;
            }
            _marketContext.SaveChanges();

            return View(model.AddToHtml, model);
        }


        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTypeRam(int id)
        {
            TypeRam typeRam = _marketContext.TypeRams.FirstOrDefault(typeRam => typeRam.Id == id);
            if (typeRam != null)
            {
                _marketContext.TypeRams.Remove(typeRam);
                _marketContext.SaveChanges();
                return View("TypeRam");
            }
            return NotFound();
        }

        #endregion

        #region CoolerType

        [HttpGet]
        public ActionResult CoolerType()
        {
            var items = _marketContext.CoolerTypes
                .Select(x => new AdditionalInfoElement
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Descrtiption,
                    PartCount = x.Coolers.Count(),
                })
                .ToList();
            var model = new AdditionalInfoTable
            {
                AddToHtml = "CoolerType",
                Elements = items,
                IsCooler = true,
            };
            return View("Index", model);
        }

        [HttpGet]
        public ActionResult CreateCoolerType()
        {
            var entity = new AdditionalInfoModel
            {
                AddToHtml = "CoolerType",
                Element = new AdditionalInfoElement
                {
                    IsCooler = true,
                },
            };
            return View("CreateEdit", entity);
        }

        [HttpGet]
        public ActionResult EditCoolerType(int id)
        {
            var entity = _marketContext.CoolerTypes
                .Select(x => new AdditionalInfoElement
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Descrtiption,
                    IsCooler = true,
                })
                .First(x => x.Id == id);
            var model = new AdditionalInfoModel
            {
                AddToHtml = "CoolerType",
                Element = entity,
            };
            return View("CreateEdit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCoolerType(AdditionalInfoModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateEdit", model);
            }

            if (model.Element.IsNew)
            {
                var entity = new CoolerTypes
                {
                    Name = model.Element.Name,
                    Descrtiption = model.Element.Description,
                };
                _marketContext.Add(entity);
            }
            else
            {
                var old = _marketContext.CoolerTypes.First(x => x.Id == model.Element.Id);
                old.Name = model.Element.Name;
                old.Descrtiption = model.Element.Description;
            }
            _marketContext.SaveChanges();

            return View(model.AddToHtml, model);
        }


        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCoolerTypes(int id)
        {
            CoolerTypes coolerType = _marketContext.CoolerTypes.FirstOrDefault(coolerType => coolerType.Id == id);
            if (coolerType != null)
            {
                _marketContext.CoolerTypes.Remove(coolerType);
                _marketContext.SaveChanges();
                return View("CoolerType");
            }
            return NotFound();
        }

        #endregion

        #region GrafProc

        [HttpGet]
        public ActionResult GrafProc()
        {
            var items = _marketContext.GrafProcs
                .Select(x => new AdditionalInfoElement
                {
                    Id = x.Id,
                    Name = x.Name,
                    Freq = x.Freq,
                    GProcs = x.GProcs,
                    PartCount = x.Videos.Count(),
                })
                .ToList();
            var model = new AdditionalInfoTable
            {
                AddToHtml = "GrafProc",
                Elements = items,
                IsGproc = true,
            };
            return View("Index", model);
        }

        [HttpGet]
        public ActionResult CreateGrafProc()
        {
            var entity = new AdditionalInfoModel
            {
                AddToHtml = "GrafProc",
                Element = new AdditionalInfoElement
                {
                    IsGprocs = true,
                },
            };
            return View("CreateEdit", entity);
        }

        [HttpGet]
        public ActionResult EditGrafProc(int id)
        {
            var entity = _marketContext.GrafProcs
                .Select(x => new AdditionalInfoElement
                {
                    Id = x.Id,
                    Name = x.Name,
                    Freq = x.Freq,
                    GProcs = x.GProcs,
                    IsGprocs = true,
                })
                .First(x => x.Id == id);
            var model = new AdditionalInfoModel
            {
                AddToHtml = "GrafProc",
                Element = entity,
            };
            return View("CreateEdit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveGrafProc(AdditionalInfoModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateEdit", model);
            }

            if (model.Element.IsNew)
            {
                var entity = new GrafProc
                {
                    Name = model.Element.Name,
                    Freq = model.Element.Freq,
                    GProcs = model.Element.GProcs,
                };
                _marketContext.Add(entity);
            }
            else
            {
                var old = _marketContext.GrafProcs.First(x => x.Id == model.Element.Id);
                old.Name = model.Element.Name;
                old.Freq = model.Element.Freq;
                old.GProcs = model.Element.GProcs;
            }
            _marketContext.SaveChanges();

            return View(model.AddToHtml, model);
        }


        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGrafProc(int id)
        {
            GrafProc grafProc = _marketContext.GrafProcs.FirstOrDefault(grafProc => grafProc.Id == id);
            if (grafProc != null)
            {
                _marketContext.GrafProcs.Remove(grafProc);
                _marketContext.SaveChanges();
                return View("GrafProc");
            }
            return NotFound();
        }

        #endregion
    }
}
