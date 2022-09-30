using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationTest1Zoologico.Models;

namespace WebApplicationTest1Zoologico.Controllers
{
    public class AnimalesController : Controller
    {
        private DbContextZoo db = new DbContextZoo();

        // GET: Animales
        public ActionResult Index()
        {
            var animales = db.Animales.Include(a => a.empleados).Include(a => a.seccionesZoo);
            return View(animales.ToList());
        }

        // GET: Animales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animales animales = db.Animales.Find(id);
            if (animales == null)
            {
                return HttpNotFound();
            }
            return View(animales);
        }

        // GET: Animales/Create
        public ActionResult Create()
        {
            ViewBag.EmpleadosId = new SelectList(db.Empleadoses, "Id", "Nombre");
            ViewBag.SeccionesZooId = new SelectList(db.SeccionesZooes, "Id", "NombreSeccion");
            return View();
        }

        // POST: Animales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreCientifico,Raza,Color,Tamaño,CaracteristicasEspeciales,LugarOrigen,PaisOrigen,RasgosDestacados,FechaLlegada,FechaTraslado,FechaDeceso,HoraAlimentacion,TipoAlimentacion,EmpleadosId,SeccionesZooId")] Animales animales)
        {
            if (ModelState.IsValid)
            {
                db.Animales.Add(animales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpleadosId = new SelectList(db.Empleadoses, "Id", "Nombre", animales.EmpleadosId);
            ViewBag.SeccionesZooId = new SelectList(db.SeccionesZooes, "Id", "NombreSeccion", animales.SeccionesZooId);
            return View(animales);
        }

        // GET: Animales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animales animales = db.Animales.Find(id);
            if (animales == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpleadosId = new SelectList(db.Empleadoses, "Id", "Nombre", animales.EmpleadosId);
            ViewBag.SeccionesZooId = new SelectList(db.SeccionesZooes, "Id", "NombreSeccion", animales.SeccionesZooId);
            return View(animales);
        }

        // POST: Animales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreCientifico,Raza,Color,Tamaño,CaracteristicasEspeciales,LugarOrigen,PaisOrigen,RasgosDestacados,FechaLlegada,FechaTraslado,FechaDeceso,HoraAlimentacion,TipoAlimentacion,EmpleadosId,SeccionesZooId")] Animales animales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpleadosId = new SelectList(db.Empleadoses, "Id", "Nombre", animales.EmpleadosId);
            ViewBag.SeccionesZooId = new SelectList(db.SeccionesZooes, "Id", "NombreSeccion", animales.SeccionesZooId);
            return View(animales);
        }

        // GET: Animales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animales animales = db.Animales.Find(id);
            if (animales == null)
            {
                return HttpNotFound();
            }
            return View(animales);
        }

        // POST: Animales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Animales animales = db.Animales.Find(id);
            db.Animales.Remove(animales);
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
