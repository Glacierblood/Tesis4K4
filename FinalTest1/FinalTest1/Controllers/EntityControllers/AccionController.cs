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
    public class AccionController : Controller
    {
        private AerDb db = new AerDb();

        // GET: Accion
        public ActionResult Index()
        {
            return View(db.Acciones.ToList());
        }

        // GET: Accion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accion accion = db.Acciones.Find(id);
            if (accion == null)
            {
                return HttpNotFound();
            }
            return View(accion);
        }

        // GET: Accion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,descripcion")] Accion accion)
        {
            if (ModelState.IsValid)
            {
                db.Acciones.Add(accion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accion);
        }

        // GET: Accion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accion accion = db.Acciones.Find(id);
            if (accion == null)
            {
                return HttpNotFound();
            }
            return View(accion);
        }

        // POST: Accion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,descripcion")] Accion accion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accion);
        }

        // GET: Accion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accion accion = db.Acciones.Find(id);
            if (accion == null)
            {
                return HttpNotFound();
            }
            return View(accion);
        }

        // POST: Accion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accion accion = db.Acciones.Find(id);
            db.Acciones.Remove(accion);
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
