using FishTracker.Data;
using FishTracker.Models.Catch;
using FishTracker.MVC.Data;
using FishTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FishTracker.MVC.Controllers
{
    [Authorize]
    public class CatchController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Catch
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CatchService(userId);
            var model = service.GetCatches();

            return View(model);
        }
        // GET: Catch
        public ActionResult Create()
        {
            return View();
        }
        // POST: Catch
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CatchCreate caught)
        {
            if (!ModelState.IsValid)
            {
                return View(caught);
            }

            var service = CreateCatchService();

            if (service.CreateCatch(caught))
            {
                TempData["SaveResult"] = "Your catch was saved.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Catch could not be saved.");

            return View(caught);
        }

        private CatchService CreateCatchService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CatchService(userId);
            return service;
        }

        // GET: Delete
        // Catch/Delete/{id}
        public ActionResult Delete(int id)
        {
            var svc = CreateCatchService();
            var model = svc.GetCatchById(id);

            return View(model);
        }
        // POST: Delete
        // Catch/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCatchService();

            service.DeleteCatch(id);

            TempData["SaveResult"] = "Your catch was deleted.";

            return RedirectToAction("Index");
        }
        // GET: Edit
        // Catch/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateCatchService();
            var detail = service.GetCatchById(id);
            var model =
                new CatchEdit()
                {
                    CatchId = detail.CatchId,
                    FishSpecies = detail.FishSpecies,
                    Length = detail.Length,
                    Weight = detail.Weight,
                    CatchDate = detail.CatchDate,
                    TypeOfLure = detail.TypeOfLure,
                    LureBrand = detail.LureBrand,
                    LureName = detail.LureName,
                    Location = detail.Location,
                    WeatherType = detail.WeatherType,
                    Temperature = detail.Temperature
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CatchEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.CatchId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateCatchService();

            if (service.UpdateCatch(model))
            {
                TempData["SaveResult"] = "Your catch has been updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your catch could not be updated.");
            return View(model);
        }
        // GET: Details
        // Catch/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateCatchService();
            var model = svc.GetCatchById(id);

            return View(model);
        }
    }
}