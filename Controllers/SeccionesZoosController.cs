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
    public class SeccionesZoosController : Controller
    {
        private DbContextZoo db = new DbContextZoo();

        // GET: SeccionesZoos
        public ActionResult Index()
        {
            return View(db.SeccionesZooes.ToList());
        }

        // GET: SeccionesZoos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeccionesZoo seccionesZoo = db.SeccionesZooes.Find(id);
            if (seccionesZoo == null)
            {
                return HttpNotFound();
            }
            return View(seccionesZoo);
        }

        // GET: SeccionesZoos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SeccionesZoos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreSeccion,Detalles")] SeccionesZoo seccionesZoo)
        {
            if (ModelState.IsValid)
            {
                db.SeccionesZooes.Add(seccionesZoo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seccionesZoo);
        }

        // GET: SeccionesZoos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeccionesZoo seccionesZoo = db.SeccionesZooes.Find(id);
            if (seccionesZoo == null)
            {
                return HttpNotFound();
            }
            return View(seccionesZoo);
        }

        // POST: SeccionesZoos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreSeccion,Detalles")] SeccionesZoo seccionesZoo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seccionesZoo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seccionesZoo);
        }

        // GET: SeccionesZoos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeccionesZoo seccionesZoo = db.SeccionesZooes.Find(id);
            if (seccionesZoo == null)
            {
                return HttpNotFound();
            }
            return View(seccionesZoo);
        }

        // POST: SeccionesZoos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SeccionesZoo seccionesZoo = db.SeccionesZooes.Find(id);
            db.SeccionesZooes.Remove(seccionesZoo);
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
