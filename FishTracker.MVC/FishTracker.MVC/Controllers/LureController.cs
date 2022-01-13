using FishTracker.Data;
using FishTracker.Models.Lure;
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
    public class LureController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Catch
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LureService(userId);
            var model = service.GetLures();

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
        public ActionResult Create(LureCreate lure)
        {
            if (!ModelState.IsValid)
            {
                return View(lure);
            }

            var service = CreateLureService();

            if (service.CreateLure(lure))
            {
                TempData["SaveResult"] = "Your lure was saved.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your lure could not be saved.");

            return View(lure);
        }

        private LureService CreateLureService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LureService(userId);
            return service;
        }

        // GET: Delete
        // Catch/Delete/{id}
        public ActionResult Delete(int id)
        {
            var svc = CreateLureService();
            var model = svc.GetLureById(id);

            return View(model);
        }
        // POST: Delete
        // Catch/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateLureService();

            service.DeleteLure(id);

            TempData["SaveResult"] = "Your lure was deleted.";

            return RedirectToAction("Index");
        }
        // GET: Edit
        // Catch/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateLureService();
            var detail = service.GetLureById(id);
            var model =
                new LureEdit()
                {
                    LureId = detail.LureId,
                    Brand = detail.Brand,
                    Name = detail.Name,
                    Color = detail.Color,
                    TypeOfLure = detail.TypeOfLure
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LureEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.LureId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateLureService();

            if (service.UpdateLure(model))
            {
                TempData["SaveResult"] = "Your lure has been updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your lure could not be updated.");
            return View(model);
        }
        // GET: Details
        // Catch/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateLureService();
            var model = svc.GetLureById(id);

            return View(model);
        }
    }
}