using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PruebaExamen.Models;

namespace PruebaExamen.Controllers
{
    public class PosicionesController : Controller
    {
        private Modelo db = new Modelo();

        // GET: Posiciones
        public ActionResult Index()
        {
            var posiciones = db.Posiciones.Include(p => p.Equipos).OrderByDescending(p=> p.puntosAcumulados);
            return View(posiciones.ToList());
        }

        // GET: Posiciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posiciones posiciones = db.Posiciones.Find(id);
            if (posiciones == null)
            {
                return HttpNotFound();
            }
            return View(posiciones);
        }

        // GET: Posiciones/Create
        public ActionResult Create()
        {
            ViewBag.idEquipo = new SelectList(db.Equipos, "idEquipo", "nombreEquipo");
            return View();
        }

        // POST: Posiciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPosicion,idEquipo,partidosJugados,partidosGanados,partidosEmpatados,partidosPerdidos,golesFavor,golesContra,diferenciaGoles,puntosAcumulados")] Posiciones posiciones)
        {
            if (ModelState.IsValid)
            {
                db.Posiciones.Add(posiciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEquipo = new SelectList(db.Equipos, "idEquipo", "nombreEquipo", posiciones.idEquipo);
            return View(posiciones);
        }

        // GET: Posiciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posiciones posiciones = db.Posiciones.Find(id);
            if (posiciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEquipo = new SelectList(db.Equipos, "idEquipo", "nombreEquipo", posiciones.idEquipo);
            return View(posiciones);
        }

        // POST: Posiciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPosicion,idEquipo,partidosJugados,partidosGanados,partidosEmpatados,partidosPerdidos,golesFavor,golesContra,diferenciaGoles,puntosAcumulados")] Posiciones posiciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posiciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEquipo = new SelectList(db.Equipos, "idEquipo", "nombreEquipo", posiciones.idEquipo);
            return View(posiciones);
        }

        // GET: Posiciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posiciones posiciones = db.Posiciones.Find(id);
            if (posiciones == null)
            {
                return HttpNotFound();
            }
            return View(posiciones);
        }

        // POST: Posiciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Posiciones posiciones = db.Posiciones.Find(id);
            db.Posiciones.Remove(posiciones);
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
