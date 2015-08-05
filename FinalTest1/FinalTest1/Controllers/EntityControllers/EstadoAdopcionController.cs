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

namespace FinalTest1.Controllers.EntityControllers
{
    public class EstadoAdopcionController : Controller
    {
        private AerDb db = new AerDb();

        // GET: EstadoAdopcion
        public ActionResult Index()
        {
            return View(db.EstadoAdopcions.ToList());
        }

        // GET: EstadoAdopcion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoAdopcion estadoAdopcion = db.EstadoAdopcions.Find(id);
            if (estadoAdopcion == null)
            {
                return HttpNotFound();
            }
            return View(estadoAdopcion);
        }

        // GET: EstadoAdopcion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoAdopcion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,descripcion")] EstadoAdopcion estadoAdopcion)
        {
            if (ModelState.IsValid)
            {
                db.EstadoAdopcions.Add(estadoAdopcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadoAdopcion);
        }

        // GET: EstadoAdopcion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoAdopcion estadoAdopcion = db.EstadoAdopcions.Find(id);
            if (estadoAdopcion == null)
            {
                return HttpNotFound();
            }
            return View(estadoAdopcion);
        }

        // POST: EstadoAdopcion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,descripcion")] EstadoAdopcion estadoAdopcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoAdopcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoAdopcion);
        }

        // GET: EstadoAdopcion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoAdopcion estadoAdopcion = db.EstadoAdopcions.Find(id);
            if (estadoAdopcion == null)
            {
                return HttpNotFound();
            }
            return View(estadoAdopcion);
        }

        // POST: EstadoAdopcion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadoAdopcion estadoAdopcion = db.EstadoAdopcions.Find(id);
            db.EstadoAdopcions.Remove(estadoAdopcion);
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
