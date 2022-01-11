using FishTracker.Data;
using FishTracker.MVC.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FishTracker.MVC.Controllers
{
    public class FishSpeciesController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Product
        public ActionResult Index()
        {
            List<FishSpecies> orderedList = _db.Species.OrderBy(spec => spec.Species).ToList();
            return View(orderedList);
        }
        // GET: Product
        public ActionResult Create()
        {
            return View();
        }
        // POST: Product
        [HttpPost]
        public ActionResult Create(FishSpecies species)
        {
            if (ModelState.IsValid)
            {
                _db.Species.Add(species);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(species);
        }
        // GET: Delete
        // Product/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            FishSpecies species = _db.Species.Find(id);
            if (species == null)
            {
                return HttpNotFound();
            }
            return View(species);
        }
        // POST: Delete
        // Product/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            FishSpecies species = _db.Species.Find(id);
            _db.Species.Remove(species);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Edit
        // Product/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            FishSpecies species = _db.Species.Find(id);
            if (species == null)
            {
                return HttpNotFound();
            }
            return View(species);
        }
        // POST: Edit
        // Product/Edit/{id}
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FishSpecies species)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(species).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(species);
        }
        // GET: Details
        // Product/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FishSpecies species = _db.Species.Find(id);

            if (species == null)
            {
                return HttpNotFound();
            }
            return View(species);
        }
    }
}