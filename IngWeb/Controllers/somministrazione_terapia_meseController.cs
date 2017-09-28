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
        private IngestDBEntities db1 = new IngestDBEntities();
        private IngestDBEntities db2 = new IngestDBEntities();
        private IngestDBEntities db3 = new IngestDBEntities();

        // GET: terapie_ospiti
        public ActionResult Index(int pOspite, string pMese, string pAnno)
        {
            if (pMese == "") { pMese = DateTime.Now.Month.ToString(); }
            ViewBag.MeseScelto = pMese;
            ViewBag.AnnoScelto = pAnno;

            DateTime datainizio = new DateTime(Int32.Parse(pAnno), Int32.Parse(pMese), 1);
            DateTime datafine = new DateTime(Int32.Parse(pAnno), Int32.Parse(pMese), DateTime.DaysInMonth(Int32.Parse(pAnno), Int32.Parse(pMese)));

            ViewBag.ultimoGiornoMese = DateTime.DaysInMonth(Int32.Parse(pAnno), Int32.Parse(pMese));
            if (datafine > DateTime.Now) { ViewBag.ultimoGiornoMese = DateTime.Now.Day; }

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

        // GET: terapie_ospiti/Delete/5
        public ActionResult CreaSomministrazione(int pIdTerapia, string pGiornoSom, string pMeseSom, string pAnnoSom)
        {

            DateTime datasomministrazione = new DateTime(Int32.Parse(pAnnoSom), Int32.Parse(pMeseSom), Int32.Parse(pGiornoSom));

            int? ospiteTerapia = 0;
            
            string StatoModificato = "";

            
            somministrazione_terapia qrysomm = (from b in db3.somministrazione_terapia
                          where b.idterapia == pIdTerapia && b.data_somministrazione == datasomministrazione
                          select b).FirstOrDefault();

            bool isNew = (qrysomm == null);

            if (isNew)
            {
                
            } else { 
            
                if (qrysomm.stato_somministrazione == "S")
                {
                    qrysomm.stato_somministrazione = "N";
                    StatoModificato = "S";
                }
                else
                {
                    qrysomm.stato_somministrazione = "S";
                    StatoModificato = "S";
                }
                try
                {
                    db3.SaveChanges();
                }
                catch (Exception e)
                {
                    StatoModificato = "";
                }

            }

            var qryterap = from a in db1.terapie_ospiti
                           where a.id == pIdTerapia
                           select a;
            foreach (var terap in qryterap)
            {
                
                if (StatoModificato == "") { 
                    somministrazione_terapia somter = new somministrazione_terapia();
                    somter.ospite = terap.ospite;
                    somter.fascia_oraria = terap.fascia_terapia;
                    somter.data_somministrazione = datasomministrazione;
                    somter.farmaco = terap.farmaco;
                    somter.posologia = terap.posologia;
                    somter.via_somministrazione = terap.via_somministrazione;
                    somter.stato_somministrazione = "S";
                    somter.idterapia = pIdTerapia;
                    db2.somministrazione_terapia.Add(somter);
                    db2.SaveChanges();
                }
                ospiteTerapia = terap.ospite;
            }
            return RedirectToAction("Index", new { pOspite = ospiteTerapia, pMese = pMeseSom, pAnno = pAnnoSom });
        }

        // GET: terapie_ospiti/Delete/5
        public ActionResult GetStatoSomministrazione(int pGetIdTerapia, string pGetGiornoSom, string pGetMeseSom, string pGetAnnoSom)
        {
            DateTime datasomministrazione = new DateTime(Int32.Parse(pGetAnnoSom), Int32.Parse(pGetMeseSom), Int32.Parse(pGetGiornoSom));
            string StatoSommTerapia = "";
            var qrysommterap = from a in db.somministrazione_terapia
                           where a.idterapia == pGetIdTerapia && a.data_somministrazione==datasomministrazione
                           select a;
            foreach (var sommterap in qrysommterap)
            {
                StatoSommTerapia = sommterap.stato_somministrazione;
            }
            string colore = "white";

            if (StatoSommTerapia == "S")
            { colore = "green"; }
            
            if (StatoSommTerapia == "N")
            { colore = "red"; }
            
            return Content(colore);
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
