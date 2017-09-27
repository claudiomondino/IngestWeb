using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IngWeb.Models;
using System.Globalization;
using System.Windows;

namespace IngWeb.Controllers
{
    public class somministrazione_terapia_meseController : Controller
    {
        private IngestDBEntities db = new IngestDBEntities();

        // GET: terapie_ospiti
        public ActionResult Index(int pOspite, string pMese, string pAnno)
        {
            if (pMese == "") { pMese = DateTime.Now.Month.ToString(); }
            ViewBag.MeseScelto = pMese;
            ViewBag.AnnoScelto = pAnno;

            DateTime datainizio = new DateTime(Int32.Parse(pAnno), Int32.Parse(pMese), 1);
            DateTime datafine = new DateTime(Int32.Parse(pAnno), Int32.Parse(pMese), DateTime.DaysInMonth(Int32.Parse(pAnno), Int32.Parse(pMese)));

            ViewBag.idOspite = pOspite;

            ViewBag.NomeOspite = (from osp in db.anagrafica_ospiti
                                       where osp.id == pOspite
                                       select osp.nome + " " + osp.cognome).First().ToString();

            var qry = (from a in db.terapie_ospiti
                       where a.ospite == pOspite &&
                       a.data_inizio <= datafine && (a.data_fine >= datainizio || a.data_fine == null)
                       orderby a.fascia_terapia
                       select a
                       );
            return View(qry.ToList());


            //return View(db.terapie_ospiti.ToList());
        }

       
        // GET: terapie_ospiti/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            terapie_ospiti terapie_ospiti = db.terapie_ospiti.Find(id);
            if (terapie_ospiti == null)
            {
                return HttpNotFound();
            }
            return View(terapie_ospiti);
        }

        // GET: terapie_ospiti/Create
        public ActionResult Create(int pOspite)
        {
            this.ViewBag.OspiteParam = pOspite;

            this.ViewBag.NomeOspite = (from osp in db.anagrafica_ospiti
                                       where osp.id == pOspite
                                       select osp.nome + " " + osp.cognome).First().ToString();

            return View();
        }

        // POST: terapie_ospiti/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ospite,data_inizio,data_fine,farmaco,posologia,via_somministrazione,stato,colazione,pranzo,cena,sera")] terapie_ospiti terapie_ospiti)
        {
            if (ModelState.IsValid)
            {
                db.terapie_ospiti.Add(terapie_ospiti);
                db.SaveChanges();
                return RedirectToAction("Index", new { pOspite = terapie_ospiti.ospite });
            }

            return View(terapie_ospiti);
        }

        // GET: terapie_ospiti/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            terapie_ospiti terapie_ospiti = db.terapie_ospiti.Find(id);
            if (terapie_ospiti == null)
            {
                return HttpNotFound();
            }
            return View(terapie_ospiti);
        }

        // POST: terapie_ospiti/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ospite,data_inizio,data_fine,farmaco,posologia,via_somministrazione,stato,colazione,pranzo,cena,sera")] terapie_ospiti terapie_ospiti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(terapie_ospiti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { pOspite = terapie_ospiti.ospite });
            }
            return View(terapie_ospiti);
        }

        // GET: terapie_ospiti/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            terapie_ospiti terapie_ospiti = db.terapie_ospiti.Find(id);
            if (terapie_ospiti == null)
            {
                return HttpNotFound();
            }
            return View(terapie_ospiti);
        }

        // POST: terapie_ospiti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            terapie_ospiti terapie_ospiti = db.terapie_ospiti.Find(id);
            db.terapie_ospiti.Remove(terapie_ospiti);
            db.SaveChanges();
            return RedirectToAction("Index", new { pOspite = terapie_ospiti.ospite });
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
