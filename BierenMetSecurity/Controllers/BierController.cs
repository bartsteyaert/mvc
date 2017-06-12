using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BierenMetSecurity.Models;

namespace BierenMetSecurity.Controllers
{
    public class BierController : Controller
    {
        private BierenEntities db = new BierenEntities();

        // GET: Bier
        public ActionResult Index()
        {
            var bieren = db.Bieren.Include(b => b.Brouwer).Include(b => b.Soort);
            return View(bieren.ToList());
        }

        // GET: Bier/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bier bier = db.Bieren.Find(id);
            if (bier == null)
            {
                return HttpNotFound();
            }
            return View(bier);
        }

        // GET: Bier/Create
        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            ViewBag.BrouwerNr = new SelectList(db.Brouwers, "BrouwerNr", "BrNaam");
            ViewBag.SoortNr = new SelectList(db.Soorten, "SoortNr", "SoortNaam");
            return View();
        }

        // POST: Bier/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "BierNr,Naam,BrouwerNr,SoortNr,Alcohol")] Bier bier)
        {
            if (ModelState.IsValid)
            {
                db.Bieren.Add(bier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrouwerNr = new SelectList(db.Brouwers, "BrouwerNr", "BrNaam", bier.BrouwerNr);
            ViewBag.SoortNr = new SelectList(db.Soorten, "SoortNr", "SoortNaam", bier.SoortNr);
            return View(bier);
        }

        // GET: Bier/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bier bier = db.Bieren.Find(id);
            if (bier == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrouwerNr = new SelectList(db.Brouwers, "BrouwerNr", "BrNaam", bier.BrouwerNr);
            ViewBag.SoortNr = new SelectList(db.Soorten, "SoortNr", "SoortNaam", bier.SoortNr);
            return View(bier);
        }

        // POST: Bier/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "BierNr,Naam,BrouwerNr,SoortNr,Alcohol")] Bier bier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrouwerNr = new SelectList(db.Brouwers, "BrouwerNr", "BrNaam", bier.BrouwerNr);
            ViewBag.SoortNr = new SelectList(db.Soorten, "SoortNr", "SoortNaam", bier.SoortNr);
            return View(bier);
        }

        // GET: Bier/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bier bier = db.Bieren.Find(id);
            if (bier == null)
            {
                return HttpNotFound();
            }
            return View(bier);
        }

        // POST: Bier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Bier bier = db.Bieren.Find(id);
            db.Bieren.Remove(bier);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
