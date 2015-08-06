using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalTest1.Contextos;
using FinalTest1.Models.Entidades;

namespace FinalTest1.Controllers
{
    public class AdopcionBORRAR2Controller : Controller
    {
        private AerDb db = new AerDb();

        // GET: AdopcionBORRAR2
        public ActionResult Index()
        {
            var adopcions = db.Adopcions.Include(a => a.animal).Include(a => a.estadoAdopcion).Include(a => a.tipoAdopcion);
            return View(adopcions.ToList());
        }

        // GET: AdopcionBORRAR2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adopcion adopcion = db.Adopcions.Find(id);
            if (adopcion == null)
            {
                return HttpNotFound();
            }
            return View(adopcion);
        }

        // GET: AdopcionBORRAR2/Create
        public ActionResult Create()
        {
            ViewBag.animalId = new SelectList(db.Animales, "Id", "nombre");
            ViewBag.estadoAdopcionId = new SelectList(db.EstadoAdopcions, "Id", "nombre");
            ViewBag.tipoAdopcionId = new SelectList(db.TipoAdopcions, "Id", "nombre");
            return View();
        }

        // POST: AdopcionBORRAR2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,voluntarioId,nombreVoluntario,animalId,admId,nombreAdm,tipoAdopcionId,estadoAdopcionId,esTemporal,fechaAlta,fechaBaja,fechaConfirmacion,fechaCancelacion,fechaEntrega,fechaFin,importe,fechaFinColaboracion")] Adopcion adopcion)
        {
            if (ModelState.IsValid)
            {
                db.Adopcions.Add(adopcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.animalId = new SelectList(db.Animales, "Id", "nombre", adopcion.animalId);
            ViewBag.estadoAdopcionId = new SelectList(db.EstadoAdopcions, "Id", "nombre", adopcion.estadoAdopcionId);
            ViewBag.tipoAdopcionId = new SelectList(db.TipoAdopcions, "Id", "nombre", adopcion.tipoAdopcionId);
            return View(adopcion);
        }

        // GET: AdopcionBORRAR2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adopcion adopcion = db.Adopcions.Find(id);
            if (adopcion == null)
            {
                return HttpNotFound();
            }
            ViewBag.animalId = new SelectList(db.Animales, "Id", "nombre", adopcion.animalId);
            ViewBag.estadoAdopcionId = new SelectList(db.EstadoAdopcions, "Id", "nombre", adopcion.estadoAdopcionId);
            ViewBag.tipoAdopcionId = new SelectList(db.TipoAdopcions, "Id", "nombre", adopcion.tipoAdopcionId);
            return View(adopcion);
        }

        // POST: AdopcionBORRAR2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,voluntarioId,nombreVoluntario,animalId,admId,nombreAdm,tipoAdopcionId,estadoAdopcionId,esTemporal,fechaAlta,fechaBaja,fechaConfirmacion,fechaCancelacion,fechaEntrega,fechaFin,importe,fechaFinColaboracion")] Adopcion adopcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adopcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.animalId = new SelectList(db.Animales, "Id", "nombre", adopcion.animalId);
            ViewBag.estadoAdopcionId = new SelectList(db.EstadoAdopcions, "Id", "nombre", adopcion.estadoAdopcionId);
            ViewBag.tipoAdopcionId = new SelectList(db.TipoAdopcions, "Id", "nombre", adopcion.tipoAdopcionId);
            return View(adopcion);
        }

        // GET: AdopcionBORRAR2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adopcion adopcion = db.Adopcions.Find(id);
            if (adopcion == null)
            {
                return HttpNotFound();
            }
            return View(adopcion);
        }

        // POST: AdopcionBORRAR2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adopcion adopcion = db.Adopcions.Find(id);
            db.Adopcions.Remove(adopcion);
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
