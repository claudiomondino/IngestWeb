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
    public class tipi_scheda_ospiteController : Controller
    {
        private IngestDBEntities db = new IngestDBEntities();

        // GET: tipi_scheda_ospite
        public ActionResult Index()
        {
            return View(db.tipi_scheda_ospite.ToList());
        }

        // GET: tipi_scheda_ospite/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipi_scheda_ospite tipi_scheda_ospite = db.tipi_scheda_ospite.Find(id);
            if (tipi_scheda_ospite == null)
            {
                return HttpNotFound();
            }
            return View(tipi_scheda_ospite);
        }

        // GET: tipi_scheda_ospite/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipi_scheda_ospite/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descrizione")] tipi_scheda_ospite tipi_scheda_ospite)
        {
            if (ModelState.IsValid)
            {
                db.tipi_scheda_ospite.Add(tipi_scheda_ospite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipi_scheda_ospite);
        }

        // GET: tipi_scheda_ospite/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipi_scheda_ospite tipi_scheda_ospite = db.tipi_scheda_ospite.Find(id);
            if (tipi_scheda_ospite == null)
            {
                return HttpNotFound();
            }
            return View(tipi_scheda_ospite);
        }

        // POST: tipi_scheda_ospite/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descrizione")] tipi_scheda_ospite tipi_scheda_ospite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipi_scheda_ospite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipi_scheda_ospite);
        }

        // GET: tipi_scheda_ospite/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipi_scheda_ospite tipi_scheda_ospite = db.tipi_scheda_ospite.Find(id);
            if (tipi_scheda_ospite == null)
            {
                return HttpNotFound();
            }
            return View(tipi_scheda_ospite);
        }

        // POST: tipi_scheda_ospite/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipi_scheda_ospite tipi_scheda_ospite = db.tipi_scheda_ospite.Find(id);
            db.tipi_scheda_ospite.Remove(tipi_scheda_ospite);
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
