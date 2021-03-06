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
using FinalTest1.ViewModel;

namespace FinalTest1.Controllers.EntityControllers
{
    [Authorize]
    public class AdopcionController : Controller
    {
        private AerDb db = new AerDb();
        private IdentityDb idb = new IdentityDb();

        // GET: Adopcion
        public ActionResult Index()
        {
            
            var adopcions = db.Adopcions.Include(a => a.animal).Include(a => a.estadoAdopcion).Include(a => a.tipoAdopcion);
            

            return View(adopcions.ToList());
        }

        // GET: Adopcion/Details/5
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

        // GET: Adopcion/Create
        public ActionResult Create()
        {
            //-------------------------------
            AdopcionViewModel modelo = new AdopcionViewModel();
            var animales = db.Animales.Include(a => a.raza).Include(a => a.tamanio);
            //var razas = db.Razas.Include(r => r.especie);
            //modelo.raza = razas;
             
            var tipoAdopcion = db.TipoAdopcions;
            modelo.tipoAdopcion = tipoAdopcion.ToList();
            modelo.animal = animales.ToList();

            //modelo.adopcion.tipoAdopcionId = ;

            //-------------------------------

            ViewBag.animalId = new SelectList(db.Animales, "Id", "nombre");
            ViewBag.estadoAdopcionId = new SelectList(db.EstadoAdopcions, "Id", "nombre");
            ViewBag.tipoAdopcionId = new SelectList(db.TipoAdopcions, "Id", "nombre");

            //ViewBag.estadoAdopcionId = new SelectList(db.EstadoAdopcions, "Id", "nombre");
            //ViewBag.adopcion_tipoAdopcionId = new SelectList(tipoAdopcion, "Id", "nombre", modelo.tipoAdopcion);
            //ViewBag.adopcion_tipoAdopcionId = new SelectList(db.TipoAdopcions, "Id", "nombre");
            //ViewBag.adopcion_tipoAdopcionIdtipoAdopcionId = new SelectList(db.TipoAdopcions, "Id", "nombre");
            return View(modelo);
        }

        // POST: Adopcion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,voluntarioId,admId,,estadoAdopcionId,esTemporal,fechaAlta,fechaBaja,fechaConfirmacion,fechaCancelacion,fechaEntrega,fechaFin,importe,fechaFinColaboracion")] Adopcion adopcion)
        public ActionResult Create([Bind(Include = "Id,voluntarioId,nombreVoluntario,animalId,tipoAdopcionId,esTemporal,fechaFin,importe,fechaFinColaboracion")] Adopcion adopcion)
        {
            adopcion.estadoAdopcionId = 1;
            adopcion.fechaAlta = System.DateTime.Now;

            

            if (ModelState.IsValid)
            {
                db.Adopcions.Add(adopcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.adopcion_tipoAdopcionId = new SelectList(db.TipoAdopcions, "Id", "nombre");
            ViewBag.estadoAdopcionId = new SelectList(db.EstadoAdopcions, "Id", "nombre", adopcion.estadoAdopcionId);
            ViewBag.tipoAdopcionId = new SelectList(db.TipoAdopcions, "Id", "nombre", adopcion.tipoAdopcionId);
            
            return View(adopcion);
        }


        // GET: Adopcion/Edit/5
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
            //ViewBag.animalId = new SelectList(db.Animales, "Id", "nombre", adopcion.animalId);
            ViewBag.estadoAdopcionId = new SelectList(db.EstadoAdopcions, "Id", "nombre", adopcion.estadoAdopcionId);
            ViewBag.tipoAdopcionId = new SelectList(db.TipoAdopcions, "Id", "nombre", adopcion.tipoAdopcionId);
            return View(adopcion);
        }

        // POST: Adopcion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,voluntarioId,nombreVoluntario,animalId,admId,nombreAdm,tipoAdopcionId,estadoAdopcionId,esTemporal,fechaBaja,fechaConfirmacion,fechaCancelacion,fechaEntrega,fechaFin, importe,fechaAlta, fechaFinColaboracion")] Adopcion adopcion)
        {
            var animalUpdate = db.Animales.Find(adopcion.animalId);
            

            if (ModelState.IsValid)
            {
                if (adopcion.estadoAdopcionId == 2) {
                    animalUpdate.enAdopcion = false;
                    adopcion.fechaConfirmacion = System.DateTime.Now;
                    db.Entry(animalUpdate).State = EntityState.Modified;
                }
                else if (adopcion.estadoAdopcionId == 3)
                {
                    animalUpdate.enAdopcion = true;                    
                    db.Entry(animalUpdate).State = EntityState.Modified;
                }
                else if (adopcion.estadoAdopcionId == 4)
                {
                    animalUpdate.enAdopcion = false;
                    adopcion.fechaEntrega = System.DateTime.Now;
                    db.Entry(animalUpdate).State = EntityState.Modified;
                }
                else if (adopcion.estadoAdopcionId == 5)
                {
                    animalUpdate.enAdopcion = true;
                    adopcion.fechaCancelacion = System.DateTime.Now;
                    db.Entry(animalUpdate).State = EntityState.Modified;
                }


                db.Entry(adopcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.animalId = new SelectList(db.Animales, "Id", "nombre", adopcion.animalId);
            ViewBag.estadoAdopcionId = new SelectList(db.EstadoAdopcions, "Id", "nombre", adopcion.estadoAdopcionId);
            ViewBag.tipoAdopcionId = new SelectList(db.TipoAdopcions, "Id", "nombre", adopcion.tipoAdopcionId);
            return View(adopcion);
        }

        // GET: Adopcion/Delete/5
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

        // POST: Adopcion/Delete/5
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
