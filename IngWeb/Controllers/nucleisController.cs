using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IngWeb.Models;
using System.Data.Entity.Infrastructure;

namespace IngWeb.Controllers
{
    public class nucleisController : Controller
    {
        private IngestDBEntities db = new IngestDBEntities();

        // GET: nucleis
        public ActionResult Index()
        {
            return View(db.nuclei.ToList());
        }

        // GET: nucleis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nuclei nuclei = db.nuclei.Find(id);
            if (nuclei == null)
            {
                return HttpNotFound();
            }

            var nucleoscelto = nuclei.nucleo_padre;
            if (nuclei.nucleo_padre == null)

                ViewBag.nucleo_padrelist = new SelectList(db.nuclei, "id", "descrizione");

            else

                ViewBag.nucleo_padrelist = new SelectList(db.nuclei.ToArray(), "id", "descrizione", nucleoscelto);

            return View(nuclei);
        }

        // GET: nucleis/Create
        public ActionResult Create()
        {
            ViewBag.nucleo_padre = new SelectList(db.nuclei, "id", "descrizione");
            return View();
        }

        // POST: nucleis/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descrizione,nucleo_padre,enabled")] nuclei nuclei)
        {
            if (ModelState.IsValid)
            {
                db.nuclei.Add(nuclei);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nuclei);
        }

        // GET: nucleis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nuclei nuclei = db.nuclei.Find(id);
            if (nuclei == null)
            {
                return HttpNotFound();
            }

            var nucleoscelto = nuclei.nucleo_padre;
            if (nuclei.nucleo_padre == null)

                ViewBag.nucleo_padrelist = new SelectList(db.nuclei, "id", "descrizione");

            else

                ViewBag.nucleo_padrelist = new SelectList(db.nuclei.ToArray(), "id", "descrizione", nucleoscelto);
            
            
                
            return View(nuclei);
        }

        // POST: nucleis/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descrizione,nucleo_padre,enabled")] nuclei nuclei)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nuclei).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nuclei);
        }

        // GET: nucleis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nuclei nuclei = db.nuclei.Find(id);
            if (nuclei == null)
            {
                return HttpNotFound();
            }

            var nucleoscelto = nuclei.nucleo_padre;
            if (nuclei.nucleo_padre == null)

                ViewBag.nucleo_padrelist = new SelectList(db.nuclei, "id", "descrizione");

            else

                ViewBag.nucleo_padrelist = new SelectList(db.nuclei.ToArray(), "id", "descrizione", nucleoscelto);

            return View(nuclei);
        }

        // POST: nucleis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            nuclei nuclei = db.nuclei.Find(id);
            db.nuclei.Remove(nuclei);
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
