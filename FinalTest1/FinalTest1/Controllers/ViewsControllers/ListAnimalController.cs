using FinalTest1.Contextos;
using FinalTest1.Models.ViewEntityes;
using FinalTest1.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using System.Data;
using System.Data.Entity;

using System.Net;


using FinalTest1.Models.Entidades;
//using Microsoft.AspNet.Identity

namespace FinalTest1.Controllers.ViewsControllers
{
    public class ListAnimalController : Controller
    {
        private AerDb db = new AerDb();
        // GET: ListAnimal
        public ActionResult Index()
        {
            AdopcionViewModel modelo = new AdopcionViewModel();
            var animales = db.Animales.Include(a => a.raza).Include(a => a.tamanio);
            var tipoAdopcion = db.TipoAdopcions;
            modelo.tipoAdopcion = tipoAdopcion.ToList();
            modelo.animal = animales.ToList();

            return View(modelo);
        }

        // GET: ListAnimal/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ListAnimal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListAnimal/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ListAnimal/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ListAnimal/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ListAnimal/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ListAnimal/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

      
    }
}
