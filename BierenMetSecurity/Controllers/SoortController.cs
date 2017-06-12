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
    public class SoortController : Controller
    {
        private BierenEntities db = new BierenEntities();

        // GET: Soort
        public ActionResult Index()
        {
            return View(db.Soorten.ToList());
        }

        // GET: Soort/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soort soort = db.Soorten.Find(id);
            if (soort == null)
            {
                return HttpNotFound();
            }
            return View(soort);
        }

        // GET: Soort/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Soort/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "SoortNr,SoortNaam")] Soort soort)
        {
            if (ModelState.IsValid)
            {
                db.Soorten.Add(soort);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(soort);
        }

        // GET: Soort/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soort soort = db.Soorten.Find(id);
            if (soort == null)
            {
                return HttpNotFound();
            }
            return View(soort);
        }

        // POST: Soort/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoortNr,SoortNaam")] Soort soort)
        {
            if (ModelState.IsValid)
            {
                db.Entry(soort).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(soort);
        }

        // GET: Soort/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soort soort = db.Soorten.Find(id);
            if (soort == null)
            {
                return HttpNotFound();
            }
            return View(soort);
        }

        // POST: Soort/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Soort soort = db.Soorten.Find(id);
            db.Soorten.Remove(soort);
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
