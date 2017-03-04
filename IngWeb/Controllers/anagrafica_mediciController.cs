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
    public class anagrafica_mediciController : Controller
    {
        private IngestDBEntities db = new IngestDBEntities();

        // GET: anagrafica_medici
        public ActionResult Index()
        {
            return View(db.anagrafica_medici.ToList());
        }

        // GET: anagrafica_medici/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anagrafica_medici anagrafica_medici = db.anagrafica_medici.Find(id);
            if (anagrafica_medici == null)
            {
                return HttpNotFound();
            }
            return View(anagrafica_medici);
        }

        // GET: anagrafica_medici/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: anagrafica_medici/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,uid,cognome,nome,data_nascita,comune_nascita,provincia_nascita,cap_nascita,codice_fiscale,indirizzo_ufficio,localita_ufficio,provincia_ufficio,cap_ufficicio,telefono,cellulare,id_regionale,indirizzo_mail,attivo_sn,user_id,cpccchk,enabled")] anagrafica_medici anagrafica_medici)
        {
            if (ModelState.IsValid)
            {
                db.anagrafica_medici.Add(anagrafica_medici);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(anagrafica_medici);
        }

        // GET: anagrafica_medici/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anagrafica_medici anagrafica_medici = db.anagrafica_medici.Find(id);
            if (anagrafica_medici == null)
            {
                return HttpNotFound();
            }
            return View(anagrafica_medici);
        }

        // POST: anagrafica_medici/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,uid,cognome,nome,data_nascita,comune_nascita,provincia_nascita,cap_nascita,codice_fiscale,indirizzo_ufficio,localita_ufficio,provincia_ufficio,cap_ufficicio,telefono,cellulare,id_regionale,indirizzo_mail,attivo_sn,user_id,cpccchk,enabled")] anagrafica_medici anagrafica_medici)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anagrafica_medici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anagrafica_medici);
        }

        // GET: anagrafica_medici/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anagrafica_medici anagrafica_medici = db.anagrafica_medici.Find(id);
            if (anagrafica_medici == null)
            {
                return HttpNotFound();
            }
            return View(anagrafica_medici);
        }

        // POST: anagrafica_medici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            anagrafica_medici anagrafica_medici = db.anagrafica_medici.Find(id);
            db.anagrafica_medici.Remove(anagrafica_medici);
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
