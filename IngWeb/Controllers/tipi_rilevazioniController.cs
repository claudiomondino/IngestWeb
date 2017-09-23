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
    public class tipi_rilevazioniController : Controller
    {
        private IngestDBEntities db = new IngestDBEntities();

        // GET: tipi_rilevazioni
        public ActionResult Index()
        {
            return View(db.tipi_rilevazioni.ToList());
        }

        // GET: tipi_rilevazioni/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipi_rilevazioni tipi_rilevazioni = db.tipi_rilevazioni.Find(id);
            if (tipi_rilevazioni == null)
            {
                return HttpNotFound();
            }
            return View(tipi_rilevazioni);
        }

        // GET: tipi_rilevazioni/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipi_rilevazioni/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descrizione,descrizione_breve,tipo_valore,numero_decimali,range_min1,range_min2,range_max1,range_max2,id_tipo_giro,unita_misura,stato")] tipi_rilevazioni tipi_rilevazioni)
        {
            if (ModelState.IsValid)
            {
                db.tipi_rilevazioni.Add(tipi_rilevazioni);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipi_rilevazioni);
        }

        // GET: tipi_rilevazioni/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipi_rilevazioni tipi_rilevazioni = db.tipi_rilevazioni.Find(id);
            if (tipi_rilevazioni == null)
            {
                return HttpNotFound();
            }
            return View(tipi_rilevazioni);
        }

        // POST: tipi_rilevazioni/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descrizione,descrizione_breve,tipo_valore,numero_decimali,range_min1,range_min2,range_max1,range_max2,id_tipo_giro,unita_misura,stato")] tipi_rilevazioni tipi_rilevazioni)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipi_rilevazioni).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipi_rilevazioni);
        }

        // GET: tipi_rilevazioni/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipi_rilevazioni tipi_rilevazioni = db.tipi_rilevazioni.Find(id);
            if (tipi_rilevazioni == null)
            {
                return HttpNotFound();
            }
            return View(tipi_rilevazioni);
        }

        // POST: tipi_rilevazioni/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipi_rilevazioni tipi_rilevazioni = db.tipi_rilevazioni.Find(id);
            db.tipi_rilevazioni.Remove(tipi_rilevazioni);
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
