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
    public class CatchController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Product
        public ActionResult Index()
        {
            List<Catch> orderedList = _db.Catches.OrderBy(cat => cat.CatchDate).ToList();
            return View(orderedList);
        }
        // GET: Product
        public ActionResult Create()
        {
            return View();
        }
        // POST: Product
        [HttpPost]
        public ActionResult Create(Catch caught)
        {
            if (ModelState.IsValid)
            {
                _db.Catches.Add(caught);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caught);
        }
        // GET: Delete
        // Product/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Catch caught = _db.Catches.Find(id);
            if (caught == null)
            {
                return HttpNotFound();
            }
            return View(caught);
        }
        // POST: Delete
        // Product/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Catch caught = _db.Catches.Find(id);
            _db.Catches.Remove(caught);
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
            Catch caught = _db.Catches.Find(id);
            if (caught == null)
            {
                return HttpNotFound();
            }
            return View(caught);
        }
        // POST: Edit
        // Product/Edit/{id}
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Catch caught)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(caught).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caught);
        }
        // GET: Details
        // Product/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catch caught = _db.Catches.Find(id);

            if (caught == null)
            {
                return HttpNotFound();
            }
            return View(caught);
        }
    }
}