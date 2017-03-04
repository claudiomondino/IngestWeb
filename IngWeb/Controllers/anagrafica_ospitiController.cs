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
    public class anagrafica_ospitiController : Controller
    {
        private IngestDBEntities db = new IngestDBEntities();

        // GET: anagrafica_ospiti
        public ActionResult Index()
        {
            return View(db.anagrafica_ospiti.ToList());
        }

        // GET: anagrafica_ospiti/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anagrafica_ospiti anagrafica_ospiti = db.anagrafica_ospiti.Find(id);
            if (anagrafica_ospiti == null)
            {
                return HttpNotFound();
            }
            return View(anagrafica_ospiti);
        }

        // GET: anagrafica_ospiti/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: anagrafica_ospiti/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,uid,codice_interno,cognome,nome,data_nascita,comune_nascita,provincia_nascita,cap_nascita,codice_fiscale,provenienza,titolo_studio,professione,stato_civile,nome_coniuge,cognome_coniuge,libretto_sanitario,numero_esenzione_ticket,grado_invalidita,indennita_accompagnamento,pensioni_rendite,codice_medico_curante,nucleo,data_ingresso,data_uscita,motivo_uscita,indirizzo_residenza,localita_residenza,provincia_residenza,cap_residenza,indirizzo_domicilio,localita_domicilio,provincia_domicilio,cap_domicilio,nome_cognome_emergenza,telefono_emergenza,nome_parente1,cognome_parente1,rapporto_parente1,telefono_parente1,indirizzo_parente1,localita_parente1,provincia_parente1,note_parente1,nome_parente2,cognome_parente2,rapporto_parente2,telefono_parente2,indirizzo_parente2,localita_parente2,provincia_parente2,note_parente2,nome_parente3,cognome_parente3,rapporto_parente3,telefono_parente3,indirizzo_parente3,localita_parente3,provincia_parente3,note_parente3,residenza_sanitaria_assistenziale,residenza_assistenziale,residenza_assistenziale_alberghiera,nome_cognome,cpccchk,enabled")] anagrafica_ospiti anagrafica_ospiti)
        {
            if (ModelState.IsValid)
            {
                db.anagrafica_ospiti.Add(anagrafica_ospiti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(anagrafica_ospiti);
        }

        // GET: anagrafica_ospiti/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anagrafica_ospiti anagrafica_ospiti = db.anagrafica_ospiti.Find(id);
            if (anagrafica_ospiti == null)
            {
                return HttpNotFound();
            }
            return View(anagrafica_ospiti);
        }

        // POST: anagrafica_ospiti/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,uid,codice_interno,cognome,nome,data_nascita,comune_nascita,provincia_nascita,cap_nascita,codice_fiscale,provenienza,titolo_studio,professione,stato_civile,nome_coniuge,cognome_coniuge,libretto_sanitario,numero_esenzione_ticket,grado_invalidita,indennita_accompagnamento,pensioni_rendite,codice_medico_curante,nucleo,data_ingresso,data_uscita,motivo_uscita,indirizzo_residenza,localita_residenza,provincia_residenza,cap_residenza,indirizzo_domicilio,localita_domicilio,provincia_domicilio,cap_domicilio,nome_cognome_emergenza,telefono_emergenza,nome_parente1,cognome_parente1,rapporto_parente1,telefono_parente1,indirizzo_parente1,localita_parente1,provincia_parente1,note_parente1,nome_parente2,cognome_parente2,rapporto_parente2,telefono_parente2,indirizzo_parente2,localita_parente2,provincia_parente2,note_parente2,nome_parente3,cognome_parente3,rapporto_parente3,telefono_parente3,indirizzo_parente3,localita_parente3,provincia_parente3,note_parente3,residenza_sanitaria_assistenziale,residenza_assistenziale,residenza_assistenziale_alberghiera,nome_cognome,cpccchk,enabled")] anagrafica_ospiti anagrafica_ospiti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anagrafica_ospiti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anagrafica_ospiti);
        }

        // GET: anagrafica_ospiti/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anagrafica_ospiti anagrafica_ospiti = db.anagrafica_ospiti.Find(id);
            if (anagrafica_ospiti == null)
            {
                return HttpNotFound();
            }
            return View(anagrafica_ospiti);
        }

        // POST: anagrafica_ospiti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            anagrafica_ospiti anagrafica_ospiti = db.anagrafica_ospiti.Find(id);
            db.anagrafica_ospiti.Remove(anagrafica_ospiti);
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
