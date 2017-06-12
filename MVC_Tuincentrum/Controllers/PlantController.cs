using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Tuincentrum.Models;
using System.IO;
using MVC_Tuincentrum.Filters;

namespace MVC_Tuincentrum.Controllers
{
    [OverrideActionFilters]
    public class PlantController : Controller
    {
        private TuinCentrumEntities db = new TuinCentrumEntities();

        // GET: Plant
        public ActionResult Index()
        {
            var planten = db.Planten.Include(p => p.Leverancier).Include(p => p.Soort);
            return View(planten.ToList());
        }

        // GET: Plant/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plant plant = db.Planten.Find(id);
            if (plant == null)
            {
                return HttpNotFound();
            }
            return View(plant);
        }

        // GET: Plant/Create
        public ActionResult Create()
        {
            ViewBag.Levnr = new SelectList(db.Leveranciers, "LevNr", "Naam");
            ViewBag.SoortNr = new SelectList(db.Soorten, "SoortNr", "Naam");
            return View();
        }

        // POST: Plant/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlantNr,Naam,SoortNr,Levnr,Kleur,VerkoopPrijs")] Plant plant)
        {
            if (ModelState.IsValid)
            {
                db.Planten.Add(plant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Levnr = new SelectList(db.Leveranciers, "LevNr", "Naam", plant.Levnr);
            ViewBag.SoortNr = new SelectList(db.Soorten, "SoortNr", "Naam", plant.SoortNr);
            return View(plant);
        }

        // GET: Plant/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plant plant = db.Planten.Find(id);
            if (plant == null)
            {
                return HttpNotFound();
            }
            ViewBag.Levnr = new SelectList(db.Leveranciers, "LevNr", "Naam", plant.Levnr);
            ViewBag.SoortNr = new SelectList(db.Soorten, "SoortNr", "Naam", plant.SoortNr);
            return View(plant);
        }

        // POST: Plant/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlantNr,Naam,SoortNr,Levnr,Kleur,VerkoopPrijs")] Plant plant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Levnr = new SelectList(db.Leveranciers, "LevNr", "Naam", plant.Levnr);
            ViewBag.SoortNr = new SelectList(db.Soorten, "SoortNr", "Naam", plant.SoortNr);
            return View(plant);
        }

        // GET: Plant/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plant plant = db.Planten.Find(id);
            if (plant == null)
            {
                return HttpNotFound();
            }
            return View(plant);
        }

        // POST: Plant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plant plant = db.Planten.Find(id);
            db.Planten.Remove(plant);
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

        [HttpGet]
        public ViewResult Uploaden(int id)
        {
            return View(id);
        }

        [HttpPost]
        public ActionResult FotoUpload(int id)
        {
            if (Request.Files.Count > 0)
            {
                var foto = Request.Files[0];
                var absoluutPadNaarDir = this.HttpContext.Server.MapPath("~/Images/Fotos");
                var absoluutPadNaarFoto = Path.Combine(absoluutPadNaarDir, id + ".jpg");
                foto.SaveAs(absoluutPadNaarFoto);
            }
            return RedirectToAction("Index");
        }

        public ContentResult ImageOrDefault(int id)
        {
            var imagePath = "/Images/Fotos/" + id + ".jpg";
            var imageSrc = System.IO.File.Exists(HttpContext.Server.MapPath("~/"+imagePath))?imagePath:"/Images/default.jpg";
            return Content(imageSrc);
        }

        public ActionResult FindPlantenBySoortNaam(string soortnaam)
        {
            List<Plant> plantenLijst = new List<Plant>();
            plantenLijst = (from plant in db.Planten.Include("Soort")
                            where plant.Soort.Naam.StartsWith(soortnaam)
                            select plant).ToList();
            return View(plantenLijst);
        }

        public ActionResult FindPlantenByLeverancier(int? levnr)
        {
            List<Plant> plantenLijst = new List<Plant>();
            plantenLijst = (from plant in db.Planten.Include("Leverancier")
                            where plant.Leverancier.LevNr == levnr
                            select plant).ToList();
            return View(plantenLijst);
        }

        public ActionResult FindPlantenBetweenPrijzen(decimal minPrijs, decimal maxPrijs)
        {
            List<Plant> plantenLijst = new List<Plant>();
            plantenLijst = (from plant in db.Planten
                            where plant.VerkoopPrijs >= minPrijs &&
                                  plant.VerkoopPrijs <= maxPrijs
                            select plant).ToList();
            ViewBag.minprijs = minPrijs;
            ViewBag.maxprijs = maxPrijs;
            return View(plantenLijst);
        }

        public ActionResult FindPlantenVanEenKleur(string kleur)
        {
            List<Plant> plantenLijst = new List<Plant>();
            plantenLijst = (from plant in db.Planten
                            where plant.Kleur == kleur
                            select plant).ToList();
            ViewBag.kleur = kleur;
            return View(plantenLijst);
        }

        [Route("plantinfo/{id:int}")]
        public ActionResult FindPlantById(int id)
        {
            var plant = db.Planten.Find(id);
            if (plant != null)
                return View("Details", plant);
            else
            {
                var planten = db.Planten.Include(p => p.Leverancier).Include(p => p.Soort);
                return View("Index", planten.ToList());
            }
        }

        [Route("plantenprijzen/{btw:values(inclusief|exclusief)}", Name ="btwinex")]
        public ActionResult PrijsLijst(string btw)
        {
            ViewBag.Btw = btw;
            return View(db.Planten.ToList());
        }
    }
}
