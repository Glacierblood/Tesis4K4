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
    public class TipoAdopcionController : Controller
    {
        private AerDb db = new AerDb();

        // GET: TipoAdopcion
        public ActionResult Index()
        {
            return View(db.TipoAdopcions.ToList());
        }

        // GET: TipoAdopcion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAdopcion tipoAdopcion = db.TipoAdopcions.Find(id);
            if (tipoAdopcion == null)
            {
                return HttpNotFound();
            }
            return View(tipoAdopcion);
        }

        // GET: TipoAdopcion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoAdopcion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,descripcion")] TipoAdopcion tipoAdopcion)
        {
            if (ModelState.IsValid)
            {
                db.TipoAdopcions.Add(tipoAdopcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoAdopcion);
        }

        // GET: TipoAdopcion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAdopcion tipoAdopcion = db.TipoAdopcions.Find(id);
            if (tipoAdopcion == null)
            {
                return HttpNotFound();
            }
            return View(tipoAdopcion);
        }

        // POST: TipoAdopcion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,descripcion")] TipoAdopcion tipoAdopcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoAdopcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoAdopcion);
        }

        // GET: TipoAdopcion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAdopcion tipoAdopcion = db.TipoAdopcions.Find(id);
            if (tipoAdopcion == null)
            {
                return HttpNotFound();
            }
            return View(tipoAdopcion);
        }

        // POST: TipoAdopcion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoAdopcion tipoAdopcion = db.TipoAdopcions.Find(id);
            db.TipoAdopcions.Remove(tipoAdopcion);
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
