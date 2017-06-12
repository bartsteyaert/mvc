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
    [Authorize(Roles = "Admin")]
    public class BrouwerController : Controller
    {
        private BierenEntities db = new BierenEntities();

        // GET: Brouwer
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Brouwers.ToList());
        }

        // GET: Brouwer/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brouwer brouwer = db.Brouwers.Find(id);
            if (brouwer == null)
            {
                return HttpNotFound();
            }
            return View(brouwer);
        }

        // GET: Brouwer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brouwer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BrouwerNr,BrNaam,Adres,PostCode,Gemeente,Omzet")] Brouwer brouwer)
        {
            if (ModelState.IsValid)
            {
                db.Brouwers.Add(brouwer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(brouwer);
        }

        // GET: Brouwer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brouwer brouwer = db.Brouwers.Find(id);
            if (brouwer == null)
            {
                return HttpNotFound();
            }
            return View(brouwer);
        }

        // POST: Brouwer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BrouwerNr,BrNaam,Adres,PostCode,Gemeente,Omzet")] Brouwer brouwer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brouwer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brouwer);
        }

        // GET: Brouwer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brouwer brouwer = db.Brouwers.Find(id);
            if (brouwer == null)
            {
                return HttpNotFound();
            }
            return View(brouwer);
        }

        // POST: Brouwer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Brouwer brouwer = db.Brouwers.Find(id);
            db.Brouwers.Remove(brouwer);
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
