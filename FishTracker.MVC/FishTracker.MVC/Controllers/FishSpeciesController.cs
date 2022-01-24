using FishTracker.Data;
using FishTracker.Models.Species;
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
    public class FishSpeciesController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Catch
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SpeciesService(userId);
            var model = service.GetSpecies();

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
        public ActionResult Create(SpeciesCreate species)
        {
            
            if (!ModelState.IsValid)
            {
                return View(species);
            }

            var service = CreateSpeciesService();

            if (service.CreateSpecies(species))
            {
                TempData["SaveResult"] = "Your species was saved.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your species could not be saved.");

            return View(species);
        }

        private SpeciesService CreateSpeciesService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SpeciesService(userId);
            return service;
        }

        // GET: Delete
        // Catch/Delete/{id}
        public ActionResult Delete(int id)
        {
            var svc = CreateSpeciesService();
            var model = svc.GetSpeciesById(id);

            return View(model);
        }
        // POST: Delete
        // Catch/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateSpeciesService();

            service.DeleteSpecies(id);

            TempData["SaveResult"] = "Your species was deleted.";

            return RedirectToAction("Index");
        }
        // GET: Edit
        // Catch/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateSpeciesService();
            var detail = service.GetSpeciesById(id);
            var model =
                new SpeciesEdit()
                {
                    SpeciesId = detail.SpeciesId,
                    SpeciesName = detail.SpeciesName,
                    AverageLength = detail.AverageLength,
                    AverageWeight = detail.AverageWeight,
                    Description = detail.Description,
                    PreferredLures = detail.PreferredLures
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SpeciesEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.SpeciesId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateSpeciesService();

            if (service.UpdateSpecies(model))
            {
                TempData["SaveResult"] = "Your species has been updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your species could not be updated.");
            return View(model);
        }
        // GET: Details
        // Catch/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateSpeciesService();
            var model = svc.GetSpeciesById(id);

            return View(model);
        }
    }
}