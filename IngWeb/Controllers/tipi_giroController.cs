using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IngWeb.Models;

namespace IngWeb.Controllers
{
    public class tipi_giroController : Controller
    {
        private IngestDBEntities db = new IngestDBEntities();

        // GET: tipi_giro
        public ActionResult Index()
        {
            return View(db.tipi_giro.ToList());
        }

        // GET: tipi_giro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipi_giro tipi_giro = db.tipi_giro.Find(id);
            if (tipi_giro == null)
            {
                return HttpNotFound();
            }
            return View(tipi_giro);
        }

        // GET: tipi_giro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipi_giro/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descrizione,ora_inizio_fascia,ora_fine_fascia,stato")] tipi_giro tipi_giro)
        {
            if (ModelState.IsValid)
            {
                db.tipi_giro.Add(tipi_giro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipi_giro);
        }

        // GET: tipi_giro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipi_giro tipi_giro = db.tipi_giro.Find(id);
            if (tipi_giro == null)
            {
                return HttpNotFound();
            }
            return View(tipi_giro);
        }

        // POST: tipi_giro/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descrizione,ora_inizio_fascia,ora_fine_fascia,stato")] tipi_giro tipi_giro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipi_giro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipi_giro);
        }

        // GET: tipi_giro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipi_giro tipi_giro = db.tipi_giro.Find(id);
            if (tipi_giro == null)
            {
                return HttpNotFound();
            }
            return View(tipi_giro);
        }

        // POST: tipi_giro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipi_giro tipi_giro = db.tipi_giro.Find(id);
            db.tipi_giro.Remove(tipi_giro);
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
