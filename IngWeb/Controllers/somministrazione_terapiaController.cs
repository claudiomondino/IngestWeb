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
    public class somministrazione_terapiaController : Controller
    {
        private IngestDBEntities db = new IngestDBEntities();
        private IngestDBEntities db2 = new IngestDBEntities();

        // GET: somministrazione_terapia
        public ActionResult Index(int pOspite)
        {

            this.ViewBag.OspiteParam = pOspite;

            this.ViewBag.NomeOspite = (from osp in db.anagrafica_ospiti
                                       where osp.id == pOspite
                                       select osp.nome + " " + osp.cognome).First().ToString();

            var qrysommin = from s in db.somministrazione_terapia
                           where s.ospite == pOspite && s.data_somministrazione == DateTime.Today
                           select s;

            // Se non sono state inserite le somministrazioni terapie per il giorno le scrivo
            if (!qrysommin.Any()) { 

                var qryterap = from a in db.terapie_ospiti
                          where a.ospite == pOspite && a.data_inizio <= DateTime.Today && a.data_fine >= DateTime.Today
                          select a;

                somministrazione_terapia somter = new somministrazione_terapia();
                foreach (var terap in qryterap)
                {
                    if (terap.colazione == "S")
                    {
                        somter.ospite = pOspite;
                        somter.fascia_oraria = "01 COLAZIONE";
                        somter.data_somministrazione = DateTime.Today;
                        somter.farmaco = terap.farmaco;
                        somter.posologia = terap.posologia;
                        somter.via_somministrazione = terap.via_somministrazione;
                        db2.somministrazione_terapia.Add(somter);
                        db2.SaveChanges();
                    }
                    if (terap.pranzo == "S")
                    {
                        somter.ospite = pOspite;
                        somter.fascia_oraria = "02 PRANZO";
                        somter.data_somministrazione = DateTime.Today;
                        somter.farmaco = terap.farmaco;
                        somter.posologia = terap.posologia;
                        somter.via_somministrazione = terap.via_somministrazione;
                        db2.somministrazione_terapia.Add(somter);
                        db2.SaveChanges();
                    }
                    if (terap.cena == "S")
                    {
                        somter.ospite = pOspite;
                        somter.fascia_oraria = "03 CENA";
                        somter.data_somministrazione = DateTime.Today;
                        somter.farmaco = terap.farmaco;
                        somter.posologia = terap.posologia;
                        somter.via_somministrazione = terap.via_somministrazione;
                        db2.somministrazione_terapia.Add(somter);
                        db2.SaveChanges();
                    }
                    if (terap.sera == "S")
                    {
                        somter.ospite = pOspite;
                        somter.fascia_oraria = "03 SERA";
                        somter.data_somministrazione = DateTime.Today;
                        somter.farmaco = terap.farmaco;
                        somter.posologia = terap.posologia;
                        somter.via_somministrazione = terap.via_somministrazione;
                        db2.somministrazione_terapia.Add(somter);
                        db2.SaveChanges();
                    }
                }

            }

            var qry = from a in db.somministrazione_terapia
                      where a.ospite == pOspite
                      select a;

            return View(qry.ToList());
        }

        // GET: somministrazione_terapia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            somministrazione_terapia somministrazione_terapia = db.somministrazione_terapia.Find(id);
            if (somministrazione_terapia == null)
            {
                return HttpNotFound();
            }
            return View(somministrazione_terapia);
        }

        // GET: somministrazione_terapia/Create
        public ActionResult Create(int pOspite)
        {
            this.ViewBag.OspiteParam = pOspite;
            return View();
        }

        // POST: somministrazione_terapia/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ospite,data_somministrazione,farmaco,posologia,via_somministrazione,stato_somministrazione,fascia_oraria,nota_operatore,operatore,data_ora")] somministrazione_terapia somministrazione_terapia)
        {
            
            if (ModelState.IsValid)
            {
                db.somministrazione_terapia.Add(somministrazione_terapia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(somministrazione_terapia);
        }

        // GET: somministrazione_terapia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            somministrazione_terapia somministrazione_terapia = db.somministrazione_terapia.Find(id);
            if (somministrazione_terapia == null)
            {
                return HttpNotFound();
            }
            return View(somministrazione_terapia);
        }

        // POST: somministrazione_terapia/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ospite,data_somministrazione,farmaco,posologia,via_somministrazione,stato_somministrazione,fascia_oraria,nota_operatore,operatore,data_ora")] somministrazione_terapia somministrazione_terapia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(somministrazione_terapia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", new { pOspite = somministrazione_terapia.ospite });
        }

        // GET: somministrazione_terapia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            somministrazione_terapia somministrazione_terapia = db.somministrazione_terapia.Find(id);
            if (somministrazione_terapia == null)
            {
                return HttpNotFound();
            }
            return View(somministrazione_terapia);
        }

        // POST: somministrazione_terapia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            somministrazione_terapia somministrazione_terapia = db.somministrazione_terapia.Find(id);
            db.somministrazione_terapia.Remove(somministrazione_terapia);
            db.SaveChanges();
            return RedirectToAction("Index", new { pOspite = somministrazione_terapia.ospite });
        }


        // STATO "OK" SU SOMMINISTRAZIONE TERAPIA
        public ActionResult Conferma(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            somministrazione_terapia somministrazione_terapia = db.somministrazione_terapia.Find(id);
            if (somministrazione_terapia == null)
            {
                return HttpNotFound();
            }

            // Aggiorno il record somministrazione con lo stato "ESEGUITO"

            (from s in db.somministrazione_terapia
             where s.id == id
                select s).ToList().ForEach(sm => sm.stato_somministrazione = "S");
            db.SaveChanges();

            return RedirectToAction("Index", new { pOspite = somministrazione_terapia.ospite });
        }

        // STATO "ANNULLA" SU SOMMINISTRAZIONE TERAPIA
        public ActionResult Annulla(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            somministrazione_terapia somministrazione_terapia = db.somministrazione_terapia.Find(id);
            if (somministrazione_terapia == null)
            {
                return HttpNotFound();
            }

            // Aggiorno il record somministrazione con lo stato "ANNULLATO"

            (from s in db.somministrazione_terapia
             where s.id == id
             select s).ToList().ForEach(sm => sm.stato_somministrazione = "A");
            db.SaveChanges();

            return RedirectToAction("Index", new { pOspite = somministrazione_terapia.ospite });
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
