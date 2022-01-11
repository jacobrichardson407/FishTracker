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
    public class LureController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Product
        public ActionResult Index()
        {
            List<Lure> orderedList = _db.Lures.OrderBy(lu => lu.Brand).ToList();
            return View(orderedList);
        }
        // GET: Product
        public ActionResult Create()
        {
            return View();
        }
        // POST: Product
        [HttpPost]
        public ActionResult Create(Lure lure)
        {
            if (ModelState.IsValid)
            {
                _db.Lures.Add(lure);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lure);
        }
        // GET: Delete
        // Product/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Lure lure = _db.Lures.Find(id);
            if (lure == null)
            {
                return HttpNotFound();
            }
            return View(lure);
        }
        // POST: Delete
        // Product/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Lure lure = _db.Lures.Find(id);
            _db.Lures.Remove(lure);
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
            Lure lure = _db.Lures.Find(id);
            if (lure == null)
            {
                return HttpNotFound();
            }
            return View(lure);
        }
        // POST: Edit
        // Product/Edit/{id}
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Lure lure)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(lure).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lure);
        }
        // GET: Details
        // Product/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lure lure = _db.Lures.Find(id);

            if (lure == null)
            {
                return HttpNotFound();
            }
            return View(lure);
        }
    }
}