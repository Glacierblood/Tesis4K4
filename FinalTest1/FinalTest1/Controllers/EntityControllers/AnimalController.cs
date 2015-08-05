﻿using System;
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
    [Authorize]
    public class AnimalController : Controller
    {
        private AerDb db = new AerDb();

        [AllowAnonymous]
        // GET: Animal
        public ActionResult Index()
        {
            var animales = db.Animales.Include(a => a.raza).Include(a => a.tamanio);
            return View(animales.ToList());
        }

        // GET: Animal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animales.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: Animal/Create
        public ActionResult Create()
        {
            ViewBag.razaId = new SelectList(db.Razas, "Id", "nombre");
            ViewBag.tamanioId = new SelectList(db.Tamanios, "Id", "nombre");
            return View();
        }

        // POST: Animal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,fechaNac,caracteristicas,tamanioId,razaId,enAdopcion")] Animal animal)
        {
            animal.fechaAlta = DateTime.Now;
            animal.edad = DateTime.Now.Year - animal.fechaNac.Year;
            



            if (ModelState.IsValid)
            {
                db.Animales.Add(animal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.razaId = new SelectList(db.Razas, "Id", "nombre", animal.razaId);
            ViewBag.tamanioId = new SelectList(db.Tamanios, "Id", "nombre", animal.tamanioId);
            return View(animal);
        }

        // GET: Animal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animales.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            ViewBag.razaId = new SelectList(db.Razas, "Id", "nombre", animal.razaId);
            ViewBag.tamanioId = new SelectList(db.Tamanios, "Id", "nombre", animal.tamanioId);
            return View(animal);
        }

        // POST: Animal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,fechaNac,caracteristicas,tamanioId,razaId,enAdopcion")] Animal animal)
        {
            animal.fechaAlta = DateTime.Now;
            animal.edad = DateTime.Now.Year - animal.fechaNac.Year;
            if (ModelState.IsValid)
            {
                db.Entry(animal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.razaId = new SelectList(db.Razas, "Id", "nombre", animal.razaId);
            ViewBag.tamanioId = new SelectList(db.Tamanios, "Id", "nombre", animal.tamanioId);
            return View(animal);
        }

        // GET: Animal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animales.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Animal animal = db.Animales.Find(id);
            db.Animales.Remove(animal);
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

        public ActionResult getEspecies()
        {

            AerDb db = new AerDb();
            var especies = db.Especies
                .Select(e => new { e.Id, e.nombre })
                .OrderBy(e => e.nombre);
            return Json(especies, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getRazas(int intCatID)
        {

            AerDb db = new AerDb();
            var razas = db.Razas
                .Where(p => p.especieID == intCatID)
                .Select(p => new { p.Id, p.nombre })
                .OrderBy(p => p.nombre);
            return Json(razas, JsonRequestBehavior.AllowGet);
        }
    }
}
