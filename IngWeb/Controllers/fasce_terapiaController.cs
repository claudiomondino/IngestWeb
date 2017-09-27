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
    public class fasce_terapiaController : Controller
    {
        private IngestDBEntities db = new IngestDBEntities();

        // GET: fasce_terapia
        public ActionResult Index()
        {
            return View(db.fasce_terapia.ToList());
        }

        // GET: fasce_terapia/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fasce_terapia fasce_terapia = db.fasce_terapia.Find(id);
            if (fasce_terapia == null)
            {
                return HttpNotFound();
            }
            return View(fasce_terapia);
        }

        // GET: fasce_terapia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: fasce_terapia/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codice,ora_inizio,ora_fine")] fasce_terapia fasce_terapia)
        {
            if (ModelState.IsValid)
            {
                db.fasce_terapia.Add(fasce_terapia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fasce_terapia);
        }

        // GET: fasce_terapia/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fasce_terapia fasce_terapia = db.fasce_terapia.Find(id);
            if (fasce_terapia == null)
            {
                return HttpNotFound();
            }
            return View(fasce_terapia);
        }

        // POST: fasce_terapia/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codice,ora_inizio,ora_fine")] fasce_terapia fasce_terapia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fasce_terapia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fasce_terapia);
        }

        // GET: fasce_terapia/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fasce_terapia fasce_terapia = db.fasce_terapia.Find(id);
            if (fasce_terapia == null)
            {
                return HttpNotFound();
            }
            return View(fasce_terapia);
        }

        // POST: fasce_terapia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            fasce_terapia fasce_terapia = db.fasce_terapia.Find(id);
            db.fasce_terapia.Remove(fasce_terapia);
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
