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
    public class PartidosController : Controller
    {
        private Modelo db = new Modelo();

        // GET: Partidos
        public ActionResult Index()
        {
            var partidos = db.Partidos.Include(p => p.Equipos);
            return View(partidos.ToList());
        }

        // GET: Partidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partidos partidos = db.Partidos.Find(id);
            if (partidos == null)
            {
                return HttpNotFound();
            }
            return View(partidos);
        }

        // GET: Partidos/Create
        public ActionResult Create()
        {
            ViewBag.idEquipo = new SelectList(db.Equipos, "idEquipo", "nombreEquipo");
            return View();
        }

        // POST: Partidos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPartido,idEquipo,fechaCreacion,golesMarcados,golesRecibidos,resultado")] Partidos partidos)
        {
            if (ModelState.IsValid)
            {
                db.Partidos.Add(partidos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEquipo = new SelectList(db.Equipos, "idEquipo", "nombreEquipo", partidos.idEquipo);
            return View(partidos);
        }

        // GET: Partidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partidos partidos = db.Partidos.Find(id);
            if (partidos == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEquipo = new SelectList(db.Equipos, "idEquipo", "nombreEquipo", partidos.idEquipo);
            return View(partidos);
        }

        // POST: Partidos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPartido,idEquipo,fechaCreacion,golesMarcados,golesRecibidos,resultado")] Partidos partidos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partidos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEquipo = new SelectList(db.Equipos, "idEquipo", "nombreEquipo", partidos.idEquipo);
            return View(partidos);
        }

        // GET: Partidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partidos partidos = db.Partidos.Find(id);
            if (partidos == null)
            {
                return HttpNotFound();
            }
            return View(partidos);
        }

        // POST: Partidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Partidos partidos = db.Partidos.Find(id);
            db.Partidos.Remove(partidos);
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
